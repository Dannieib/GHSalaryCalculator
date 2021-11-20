using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GHSalaryCalculator.Service.Dto
{
    public class ProcessGrossSalaryDto
    {
        public string UserName { get; set; } = "Anonymous";
        public decimal GrossSalary { get; set; }
        public decimal NetSalary { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal PensionAmount { get; set; }
        public string TaxDeductionPercentage { get; set; }
        public string PensionDeductionPercentage { get; set; }
        public string Message { get; set; }
        public DateTime DateProcessed { get; set; }
    }
}
