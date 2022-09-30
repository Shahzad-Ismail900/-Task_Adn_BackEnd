

using CRUD.Controllers;
using CRUD.Interfaces;
using CRUD.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class AuthenticationController : BaseController
    {

        private readonly IJWTManagerRepository _jWTManager;

        public AuthenticationController(IJWTManagerRepository jWTManager)
        {
            this._jWTManager = jWTManager;
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("authenticate")]
        public IActionResult Authenticate(AppUser usersdata)
        {
            try
            {
                var token = _jWTManager.Authenticate(usersdata);

                if (token == null)
                {
                    return BadResponse("Invalid User..!");
                }

               
                return SucessResponse(token);
            }
            catch (Exception Ex)
            {

                return BadResponse(new { data = "", isSucessful = false, Errors = Ex.Message });
            }
           
        }
    }
}
