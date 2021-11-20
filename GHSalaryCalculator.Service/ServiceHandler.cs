using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GHSalaryCalculator.Core.Configs;
using GHSalaryCalculator.Service.Dto;
using GHSalaryCalculator.Service.HelperServices.PensionHelper;
using GHSalaryCalculator.Service.HelperServices.TaxHelper;
using Microsoft.Extensions.Options;

namespace GHSalaryCalculator.Service
{
    public class ServiceHandler : IServiceHandler
    {
        private readonly List<PensionDeductionConfig> _pensionConfig;
        private readonly List<TaxDeductionConfig> _taxConfig;

        public ServiceHandler(IOptions<List<PensionDeductionConfig>> options, IOptions<List<TaxDeductionConfig>> optionsSnapshot)
        {
            _pensionConfig = options.Value;
            _taxConfig = optionsSnapshot.Value;
        }

        public async Task<ProcessGrossSalaryDto> ProcessGrossSalary(string userName, decimal grossSalary)
        {
            try
            {
                var netSalary = 0.0m;

                if (grossSalary <= 0)
                {
                    return await Task.FromResult<ProcessGrossSalaryDto>(new ProcessGrossSalaryDto
                    {
                        Message = "Validation Error: Cannot process expected gross salary.",
                        DateProcessed = DateTime.Now,
                        PensionDeductionPercentage = "0",
                        TaxDeductionPercentage = "0",
                        GrossSalary = grossSalary,
                        NetSalary = 0,
                        TaxAmount = 0,
                        PensionAmount = 0,
                        UserName = !string.IsNullOrEmpty(userName)?userName:"Anonymous"
                    });
                }

                var pensionProcessor = PensionServiceHelper.ProcessPension(grossSalary, _pensionConfig);
                var taxProcessor = TaxServiceHelper.ProcessPayeeTax(grossSalary, _taxConfig);

                netSalary = grossSalary - taxProcessor.CalculatedTax;
                netSalary = grossSalary - pensionProcessor.DebitedPension;

                //Basic Salary, Total PAYEE Tax, Employee Pension Contribution Amount and Employer Pension amount.
                //I had added extra responses.
                return await Task.FromResult(new ProcessGrossSalaryDto
                {
                    Message = "Success: Successfully processed.",
                    DateProcessed = DateTime.Now,
                    PensionDeductionPercentage = pensionProcessor.PensionPercentage,
                    TaxDeductionPercentage = $"{taxProcessor.TaxPercentage}%",
                    GrossSalary = grossSalary,
                    NetSalary = netSalary,
                    TaxAmount = taxProcessor.CalculatedTax,
                    PensionAmount = pensionProcessor.CalculatedPension,
                    UserName = !string.IsNullOrEmpty(userName) ? userName : "Anonymous"
                });
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
