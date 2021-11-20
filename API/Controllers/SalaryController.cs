using System;
using System.Threading.Tasks;
using GHSalaryCalculator.Service;
using GHSalaryCalculator.Service.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GHSalaryCalculator.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SalaryController : ControllerBase
    {

        private readonly ILogger<SalaryController> _logger;
        private readonly IServiceHandler _serviceHandler;

        public SalaryController(ILogger<SalaryController> logger, IServiceHandler serviceHandler)
        {
            _logger = logger;
            _serviceHandler = serviceHandler;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ProcessGrossSalaryDto),200)]
        [ProducesResponseType(typeof(ProcessGrossSalaryDto),500)]
        public async Task<IActionResult> ProcessGrossSalary(string userName, decimal grossSalary)
        {
            try
            {
                var resp = await _serviceHandler.ProcessGrossSalary(userName, grossSalary);
                return Ok(resp);
            }
            catch (Exception e)
            {
                _logger.LogCritical(e.Message,e);
                throw;
            }
        }
    }
}
