using AutoMapper;
using BusinessLayer.Model.Interfaces;
using BusinessLayer.Model.Models;
using BusinessLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class EmployeeController : ApiController
    {
        log4net.ILog log = log4net.LogManager.GetLogger(typeof(EmployeeController));
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;
        public EmployeeController(IEmployeeService employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IHttpActionResult> Post([FromBody] EmployeeDto value)
        {
          
            var item = _mapper.Map<EmployeeInfo>(value);
            await _employeeService.SaveEmployeeAsync(item);
            log.Info("data processing info");
            var resHttpMsg = new HttpResponseMessage(HttpStatusCode.Created);

            return ResponseMessage(resHttpMsg);
        }
        [Route("api/Employee/{id}")]
        [HttpGet]        
        public async Task<IHttpActionResult>  Get(int id)
        {
            var result =await _employeeService.FindEmployeeAsync(id);
            var res= _mapper.Map<EmployeeDto>(result);
            return Ok(res);
        }

    
    }
}
