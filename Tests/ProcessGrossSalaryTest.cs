using System;
using System.Collections.Generic;
using FluentAssertions;
using GHSalaryCalculator.Core.Configs;
using GHSalaryCalculator.Service;
using Microsoft.Extensions.Options;
using Moq;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class ProcessGrossSalaryTest
    {
        private IServiceHandler _handler;
       
        [SetUp]
        public void Setup()
        {
        var taxConfig = new List<TaxDeductionConfig>
        {
            new TaxDeductionConfig
            {
                UpperBoundAmount = 1000,
                LowerBoundAmount = 0,
                PercentageValue = 13
            }
        };

        var pensionConfig = new List<PensionDeductionConfig>
        {
            new PensionDeductionConfig
            {
                Tier = "tier 1",
                UpperBoundAmount = 1000,
                LowerBoundAmount = 1.0m,
                EmployeeRate = 5.5m,
                EmployerRate = 0.0m
            }
        };

        var pension = new Mock<IOptions<List<PensionDeductionConfig>>>();
            pension.Setup(x => x.Value).Returns(pensionConfig);

            var tax = new Mock<IOptions<List<TaxDeductionConfig>>>();
            tax.Setup(x => x.Value).Returns(taxConfig);

            _handler = new ServiceHandler(pension.Object,tax.Object);
        }

        [Test]
        public void Process_Gross_Salary_Returns_Success()
        {
            var grossSalary = 20000m;
            var employeeUserName = "Samuel Ephson";
            var resp = _handler.ProcessGrossSalary(employeeUserName, grossSalary).Result;
            resp.Should().NotBe(null);
            resp.NetSalary.Should().NotBe(Decimal.Zero);
        }
    }
}
