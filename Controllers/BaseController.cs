using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {

        protected IActionResult SucessResponse(object data)
        {
            return Ok(new ApiResponse { data = data, errors = null, isSucessful = true });
        }
        protected IActionResult BadResponse(object data)
        {
            return Ok(new ApiResponse { data = null, errors = data, isSucessful = false });
        }

    }
}


public class ApiResponse
{
    public bool isSucessful { get; set; }
    public object data { get; set; }

    public object errors { get; set; }
}
