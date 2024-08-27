using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BusinessLayer.Model.Models;

namespace BusinessLayer.Model.Interfaces
{
    public interface ICompanyService
    {
        IEnumerable<CompanyInfo> GetAllCompanies();
        CompanyInfo GetCompanyByCode(string companyCode);
        Task<bool> SaveEmployeeAsync(CompanyInfo company);


        Task<bool> UpdateCompanyAsync(int id,CompanyInfo company);

        Task<bool> DeleteCompanyAsync(int id);

        Task<CompanyInfo> FindCompanyAsync(int id);
        Task<IEnumerable<CompanyInfo>> FindAllCompanyAsync();

    }
}
