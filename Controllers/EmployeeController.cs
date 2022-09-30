using CRUD.Interfaces;
using CRUD.Models;
using CRUD.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CRUD.Controllers
{
    [Authorize]
    public class EmployeeController : BaseController
    {
        private readonly IEmp _empRepo;
        private readonly ILogService _logService;
      
        public EmployeeController(IEmp empRepo, ILogService logService)
        {
            _empRepo = empRepo;
            _logService = logService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var EmpList = _empRepo.GetEmpList();

                return SucessResponse(EmpList);
            }
            catch (Exception Ex)
            {

                return BadResponse(new { data = "", isSucessful = false, Errors = Ex.Message });
            }
        }

        [HttpGet("{empId}/detail")]
        public IActionResult GetDeptById(int empId)
        {
            try
            {
                var EmpList = _empRepo.GetEmpById(empId);

                return SucessResponse(EmpList);
            }
            catch (Exception Ex)
            {

                return BadResponse(new { data = "", isSucessful = false, Errors = Ex.Message });
            }
        }


        [HttpPost]
        public IActionResult Post(Employee obj)
        {
            try
            {
                ApiResponse emobj = _empRepo.SaveEmp(obj);
                _logService.CreateLog(new LogUserActivity
                {
                    FormName = "Employee",
                    Action = obj.EmpId == 0 ? "CREATE" : "UPDATE",
                    Status = emobj.isSucessful ? "SUCCESS" : "ERROR",
                    Description = "Track User Activity",
                    LoggedBy = obj.CreatedBy

                });
                return SucessResponse(emobj);
            }
            catch (Exception Ex)
            {
                return BadResponse(new { data = "", isSucessful = false, Errors = Ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                ApiResponse emobj = _empRepo.DeleteEmp(id);
                _logService.CreateLog(new LogUserActivity
                {
                    FormName = "Employee",
                    Action = emobj.isSucessful ? "DELETE" : "ERROR",
                    Status = emobj.isSucessful ? "SUCCESS" : "ERROR",
                    Description = "Track User Activity while deleting..!",
                    LoggedBy = 1

                });
                return SucessResponse(emobj);
            }
            catch (Exception Ex)
            {
                return BadResponse(new { data = "", isSucessful = false, Errors = Ex.Message });
            }
        }

        [HttpGet("employeeType")]
        public IActionResult GetAllEmployeeType()
        {
            try
            {
                var EmpList = _empRepo.GetAllEmployeeType();

                return SucessResponse(EmpList);
            }
            catch (Exception Ex)
            {

                return BadResponse(new { data = "", isSucessful = false, Errors = Ex.Message });
            }
        }

        [HttpGet("employeeStatus")]
        public IActionResult GetAllEmployeesStatus()
        {
            try
            {
                var EmpList = _empRepo.GetAllEmployeesStatus();

                return SucessResponse(EmpList);
            }
            catch (Exception Ex)
            {

                return BadResponse(new { data = "", isSucessful = false, Errors = Ex.Message });
            }
        }


    }
}

