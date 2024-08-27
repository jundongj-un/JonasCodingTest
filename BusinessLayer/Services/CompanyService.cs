using BusinessLayer.Model.Interfaces;
using System.Collections.Generic;
using AutoMapper;
using BusinessLayer.Model.Models;
using DataAccessLayer.Model.Interfaces;
using DataAccessLayer.Model.Models;
using System.Xml.XPath;
using System.Threading.Tasks;
using System.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace BusinessLayer.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public CompanyService(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

       

        public IEnumerable<CompanyInfo> GetAllCompanies()
        {
            var res = _companyRepository.GetAll();
            return _mapper.Map<IEnumerable<CompanyInfo>>(res);
        }

        public CompanyInfo GetCompanyByCode(string companyCode)
        {
            var result = _companyRepository.GetByCode(companyCode);
            return _mapper.Map<CompanyInfo>(result);
        }

       
        public async Task<bool> SaveEmployeeAsync(CompanyInfo company)
        {

            var result = _mapper.Map<Company>(company);
            return await _companyRepository.SaveEmployeeAsync(result);

        }

        public async Task<CompanyInfo> FindCompanyAsync(int id)
        {
            var result =await _companyRepository.FindCompanyAsync(id);
            var res =_mapper.Map<IEnumerable<CompanyInfo>>(result);           
            return res?.FirstOrDefault();
            

        }

        public async Task<IEnumerable<CompanyInfo>> FindAllCompanyAsync()
        {
            var result= await _companyRepository.GetAllCompanyAsync();
            return _mapper.Map<IEnumerable<CompanyInfo>>(result);

        }

        public async Task<bool> UpdateCompanyAsync(int id, CompanyInfo company)
        {

           var result= _mapper.Map<Company>(company);

            return await _companyRepository.UpdateCompanyAsync(id, result);
        }

        public async Task<bool> DeleteCompanyAsync(int id)
        {
            return await _companyRepository.DeleteCompanyAsync(id);


        }
    }
}
