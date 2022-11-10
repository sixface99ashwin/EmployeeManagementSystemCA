using AutoFixture;
using AutoMapper;
using EmployeeManagementSystemCA.Controllers;
using EmployeeManagementSystemCA.Core.IRepository;
using EmployeeManagementSystemCA.DTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystemTests
{
    [TestClass]
    public class EmployeeControllerTests
    {
        private Mock<IEmployee> _employeeRepository;
        private Fixture _fixture;
        private EmployeeController _controller;

        public EmployeeControllerTests()
        {
            _fixture=new Fixture();
            _employeeRepository = new Mock<IEmployee>();
        }

        [TestMethod]
        public async Task Get_Employee_ReturnOk()
        {
            var fixture =new Fixture().Customize(new AutoConfiguredMoqCustomization())
            var  employeeList =  _fixture.CreateMany<Task<IEnumerable<EmployeeDto>>>(3).ToList();

           await _employeeRepository.Setup(repo => repo.GetAllEmployees()).Returns(employeeList);
        }
    }
}
