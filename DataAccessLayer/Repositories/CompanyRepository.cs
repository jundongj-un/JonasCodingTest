﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Model.Interfaces;
using DataAccessLayer.Model.Models;


namespace DataAccessLayer.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly IDbWrapper<Company> _companyDbWrapper;

        public CompanyRepository(IDbWrapper<Company> companyDbWrapper)
        {
            _companyDbWrapper = companyDbWrapper;
        }

      

        public IEnumerable<Company> GetAll()
        {
            return _companyDbWrapper.FindAll();
        }

        public Company GetByCode(string companyCode)
        {
            return _companyDbWrapper.Find(t => t.CompanyCode.Equals(companyCode))?.FirstOrDefault();
        }

        public bool SaveCompany(Company company)
        {
            var itemRepo = _companyDbWrapper.Find(t =>
                t.SiteId.Equals(company.SiteId) && t.CompanyCode.Equals(company.CompanyCode))?.FirstOrDefault();
            if (itemRepo != null)
            {
                itemRepo.CompanyName = company.CompanyName;
                itemRepo.AddressLine1 = company.AddressLine1;
                itemRepo.AddressLine2 = company.AddressLine2;
                itemRepo.AddressLine3 = company.AddressLine3;
                itemRepo.Country = company.Country;
                itemRepo.EquipmentCompanyCode = company.EquipmentCompanyCode;
                itemRepo.FaxNumber = company.FaxNumber;
                itemRepo.PhoneNumber = company.PhoneNumber;
                itemRepo.PostalZipCode = company.PostalZipCode;
                itemRepo.LastModified = company.LastModified;
                return _companyDbWrapper.Update(itemRepo);
            }

            return _companyDbWrapper.Insert(company);
        }

        public async Task<bool> SaveEmployeeAsync(Company company)
        {
            return await _companyDbWrapper.InsertAsync(company);
        }
        public async Task<bool> DeleteCompanyAsync(int id)
        {
            return await _companyDbWrapper.DeleteAsync(x => x.SiteId == id.ToString());
        }

        public async Task<IEnumerable<Company>> FindCompanyAsync(int id)
        {

            return await _companyDbWrapper.FindAsync(x => x.SiteId == (id.ToString()));
        }

        public async Task<IEnumerable<Company>> GetAllCompanyAsync()
        {

            return await _companyDbWrapper.FindAllAsync();
        }
        public async Task<bool> UpdateCompanyAsync(int id, Company company)
        {
            return await _companyDbWrapper.UpdateAsync(company);
        }
    }
}
