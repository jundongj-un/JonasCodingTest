using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Model.Models;

namespace DataAccessLayer.Model.Interfaces
{
    public interface ICompanyRepository
    {
        IEnumerable<Company> GetAll();
        Company GetByCode(string companyCode);
        bool SaveCompany(Company company);
        Task<bool> SaveEmployeeAsync(Company company);
        Task<IEnumerable<Company>> FindCompanyAsync(int id);
        Task<IEnumerable<Company>> GetAllCompanyAsync();
        Task<bool> UpdateCompanyAsync(int id, Company company);
        Task<bool> DeleteCompanyAsync(int id);
    }
}
