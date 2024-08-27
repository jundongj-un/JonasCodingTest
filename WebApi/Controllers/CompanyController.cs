using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using BusinessLayer.Model.Interfaces;
using BusinessLayer.Model.Models;
using BusinessLayer.Services;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class CompanyController : ApiController
    {
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;

        public CompanyController(ICompanyService companyService, IMapper mapper)
        {
            _companyService = companyService;
            _mapper = mapper;
        }
        //// GET api/<controller>

        //public IEnumerable<CompanyDto> GetAll()
        //{
        //    var items = _companyService.GetAllCompanies();
        //    return _mapper.Map<IEnumerable<CompanyDto>>(items);
        //}

        //// GET api/<controller>/5
        //public CompanyDto Get(string companyCode)
        //{
        //    var item = _companyService.GetCompanyByCode(companyCode);
        //    return _mapper.Map<CompanyDto>(item);
        //}
        //// POST api/<controller>
        //public void Post([FromBody]string value)
        //{
        //}

        // PUT api/<controller>/5
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/<controller>/5
        //public void Delete(int id)
        //{

        //}

        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {
            var items =await  _companyService.FindAllCompanyAsync();
            return Ok(_mapper.Map<IEnumerable<CompanyDto>>(items));
        }

        [Route("api/Company/{companyCode}")]
        [HttpGet]
        public async Task<IHttpActionResult> Get(string companyCode)
        {
            var item = _companyService.GetCompanyByCode(companyCode);
            return Ok(_mapper.Map<CompanyDto>(item));
        }


       [HttpPost]
        public async Task<IHttpActionResult> Post([FromBody] CompanyDto value)
        {
           
            var item = _mapper.Map<CompanyInfo>(value);
            await _companyService.SaveEmployeeAsync(item);
            var resHttpMsg = new HttpResponseMessage(HttpStatusCode.Created);

            return ResponseMessage(resHttpMsg);
        }

       
        [Route("api/Company/{id}")]
        [HttpPut]
        public async Task<IHttpActionResult> Put(int id, [FromBody] CompanyDto value)
        {
            
            var item = _mapper.Map<CompanyInfo>(value);
            await _companyService.UpdateCompanyAsync(id, item);

            var resHttpMsg = new HttpResponseMessage(HttpStatusCode.NoContent);
            return ResponseMessage(resHttpMsg);
            
        }


        [Route("api/Company/{id}")]
        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {

            await  _companyService.DeleteCompanyAsync(id);
            var resHttpMsg = new HttpResponseMessage(HttpStatusCode.NoContent);
            return ResponseMessage(resHttpMsg);
        }
    }
}