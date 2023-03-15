using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodingTestModel.Models;
using CodingTestService.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodingTestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CodingController : ControllerBase
    {
        private ICodeTestingService _codeTestingService;
        public CodingController(ICodeTestingService codeTestingService)
        {
            _codeTestingService = codeTestingService;
        }

        [HttpGet]
        public async Task<List<userDetail>> Get()
        {
            return await _codeTestingService.GetAllUserDetails();
        }
    }
}