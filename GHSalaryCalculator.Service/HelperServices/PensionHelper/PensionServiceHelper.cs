using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GHSalaryCalculator.Core.Configs;
using GHSalaryCalculator.Service.Dto;

namespace GHSalaryCalculator.Service.HelperServices.PensionHelper
{
    public static class PensionServiceHelper
    {
        public static PensionDto ProcessPension(decimal grossSalary, List<PensionDeductionConfig> pensionConfig)
        {
            var employeePensionPercentage = 0.0m;
            var employerPensionPercentage = 0.0m;
            var employerPensionCalc = 0.0m;
            var employeePensionCalc = 0.0m;

            for(int i = 0; i < pensionConfig.Count; i++)
            {
                if(grossSalary >= pensionConfig[i].LowerBoundAmount &&
                    grossSalary <= pensionConfig[i].UpperBoundAmount)
                {
                    employeePensionPercentage = pensionConfig[i].EmployeeRate;
                    employerPensionPercentage = pensionConfig[i].EmployerRate;
                    break;
                }
            }
            
            if (employerPensionPercentage > 0)
            {
                employerPensionCalc = grossSalary * employerPensionPercentage / 100;
            }

            if (employeePensionPercentage > 0)
            {
                //we only deduct employee's percentage from the grass salary
                employeePensionCalc = grossSalary * employeePensionPercentage / 100;
            }

            var ffs = employerPensionPercentage > 0
                ? $"Employer: {employerPensionPercentage}%" : $"Employee: {employeePensionPercentage}%";

            var pensionPercent = employerPensionPercentage > 0 && employeePensionPercentage > 0
                ? $"Employee: {employerPensionPercentage}% / Employee: {employeePensionPercentage}%" : ffs;

            //this point displays to the woman to know how much would be her pension
            var addedPension = employerPensionCalc + employeePensionCalc;

            return new PensionDto
            {
                PensionPercentage = pensionPercent,
                CalculatedPension = addedPension,
                DebitedPension = employeePensionCalc
            };
        }
    }
}
