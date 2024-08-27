using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.Model.Interfaces;
using BusinessLayer.Model.Models;
using DataAccessLayer.Model.Interfaces;
using DataAccessLayer.Model.Models;

namespace BusinessLayer.Services
{
    public class EmployeeService : IEmployeeService
    {

        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }
        public async Task<EmployeeInfo> FindEmployeeAsync(int id)
        {
            
            var result = await _employeeRepository.GetEmployeeeAsync(id);

            var res = _mapper.Map<IEnumerable<EmployeeInfo>>(result);
            return res?.FirstOrDefault();
            


        }

        public async Task<bool> SaveEmployeeAsync(EmployeeInfo employee)
        {
            
            var result = _mapper.Map<Employee>(employee);
            return await _employeeRepository.SaveEmployeeAsync(result);


        }
    }
}
