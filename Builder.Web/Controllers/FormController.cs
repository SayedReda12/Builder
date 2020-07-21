using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Builder.Application.Form;
using Builder.Common.Response;
using Builder.Domain.Dtos.Form;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Builder.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormController : ControllerBase
    {
        private readonly IFormAppService _formAppService;

        public FormController(IFormAppService formAppService)
        {
            this._formAppService = formAppService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetForm(Guid id)
        {
            var result = await _formAppService.GetAsync(id);

            return Ok(new ApiResponse(result));
        }

        [HttpGet("All")]
        [ProducesResponseType(typeof(IEnumerable<FormDto>), 200)]

        public async Task<IActionResult> GetAllForms()
        {
            var result = await _formAppService.GetAllAsync();

            return Ok(new ApiResponse(result));
        }
    }
}
