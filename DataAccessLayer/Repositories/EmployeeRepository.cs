using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Model.Interfaces;
using DataAccessLayer.Model.Models;

namespace DataAccessLayer.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IDbWrapper<Employee> _employeeDbWrapper;

        public EmployeeRepository(IDbWrapper<Employee> employeeDbWrapper)
        {
            _employeeDbWrapper = employeeDbWrapper;
        }
       
        public async Task<bool> SaveEmployeeAsync(Employee employee)
        {
            return await _employeeDbWrapper.InsertAsync(employee);
        }

        public async Task<IEnumerable<Employee>> GetEmployeeeAsync(int id)
        {
          
          return  await _employeeDbWrapper.FindAsync(x => x.SiteId == (id.ToString()));
        }
    }
}
