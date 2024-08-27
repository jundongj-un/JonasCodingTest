using BusinessLayer.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Model.Interfaces
{
    public interface IEmployeeService
    {
        Task<EmployeeInfo> FindEmployeeAsync(int id);
        Task<bool> SaveEmployeeAsync(EmployeeInfo employee);
    }
}
