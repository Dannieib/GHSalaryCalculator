using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GHSalaryCalculator.Core.Configs
{
    public class PensionDeductionConfig
    {
        public string Tier { get; set; }
        public decimal EmployeeRate { get; set; }
        public decimal EmployerRate { get; set; }
        public decimal LowerBoundAmount { get; set; }
        public decimal UpperBoundAmount { get; set; }
    }
}
