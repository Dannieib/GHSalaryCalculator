using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GHSalaryCalculator.Core.Configs;
using GHSalaryCalculator.Service.Dto;

namespace GHSalaryCalculator.Service.HelperServices.TaxHelper
{
    public static class TaxServiceHelper
    {
        public static PayeeTaxDto ProcessPayeeTax(decimal grossSalary, List<TaxDeductionConfig> taxConfig)
        {
            var taxPercentage = 0.0m;

            for (int i = 0; i < taxConfig.Count; i++)
            {
                if (grossSalary >= taxConfig[i].LowerBoundAmount && grossSalary <= taxConfig[i].UpperBoundAmount)
                {
                    taxPercentage = taxConfig[i].PercentageValue;
                    break;
                }
            }

            var taxCalc = grossSalary * taxPercentage / 100;

            return new PayeeTaxDto
            {
                TaxPercentage = taxPercentage,
                CalculatedTax = taxCalc
            };
        }
    }
}
