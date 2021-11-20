using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GHSalaryCalculator.Service.Dto
{
    public class PensionDto
    {
        public string PensionPercentage { get; set; }
        public decimal CalculatedPension { get; set; }
        public decimal DebitedPension { get; set; }
    }
}
