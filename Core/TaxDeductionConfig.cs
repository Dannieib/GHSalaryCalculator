using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GHSalaryCalculator.Core.Configs
{
    public class TaxDeductionConfig
    {
        public decimal LowerBoundAmount { get; set; }
        public decimal UpperBoundAmount { get; set; }
        public decimal PercentageValue { get; set; }
    }
}
