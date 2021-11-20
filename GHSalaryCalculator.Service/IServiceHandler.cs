using System.Collections.Generic;
using System.Threading.Tasks;
using GHSalaryCalculator.Core.Configs;
using GHSalaryCalculator.Service.Dto;

namespace GHSalaryCalculator.Service
{
    public interface IServiceHandler
    {
        Task<ProcessGrossSalaryDto> ProcessGrossSalary(string userName, decimal grossSalary);
    }
}