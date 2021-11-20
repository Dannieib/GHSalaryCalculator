using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GHSalaryCalculator.Service.Dto
{
    public class PayeeTaxDto
    {
        public decimal TaxPercentage { get; set; }
        public decimal CalculatedTax { get; set; }
    }
}
