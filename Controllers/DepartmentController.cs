using CRUD.Interfaces;
using CRUD.Models;
using CRUD.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CRUD.Controllers
{

    public class DepartmentController : BaseController
    {

        private readonly IDepartment _deptRepo;
        private readonly ILogService _logService;

        public DepartmentController(IDepartment deptRepo,ILogService logService)
        {
            _deptRepo = deptRepo;
            _logService = logService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var deptList = _deptRepo.GetDeptList();
                return SucessResponse(deptList);
            }
            catch (Exception Ex)
            {

                return BadResponse(new { data = "", isSucessful = false, Errors = Ex.Message });
            }
        }

        [HttpGet("{deptId}/detail")]
        public IActionResult GetDeptById(int deptId)
        {
            try
            {
                var deptList = _deptRepo.GetDeptById(deptId);

                return SucessResponse(deptList);
            }
            catch (Exception Ex)
            {
                return BadResponse(new { data = "", isSucessful = false, Errors = Ex.Message });
            }
        }


        [HttpPost]
        public IActionResult Post(Department obj)
        {
            try
            {
                ApiResponse deptbj = _deptRepo.SaveDept(obj);
                _logService.CreateLog(new LogUserActivity
                {
                    FormName = "Department",
                    Action = obj.DeptId == 0 ? "CREATE" : "UPDATE",
                    Status = deptbj.isSucessful ? "SUCCESS" : "ERROR",
                    Description = "Track User Activity"

                });
                return SucessResponse(deptbj);
            }
            catch (Exception Ex)
            {
                return BadResponse(new { data = "", isSucessful = false, Errors = Ex.Message });
            }

        }

        [HttpDelete("{id}/delete")]
        public IActionResult Delete(int id)
        {
            try
            {
                ApiResponse emobj = _deptRepo.DeleteDept(id);
                _logService.CreateLog(new LogUserActivity
                {
                    FormName = "Department",
                    Action = emobj.isSucessful ? "DELETE" : "ERROR",
                    Status = emobj.isSucessful ? "SUCCESS" : "ERROR",
                    Description = "Track User Activity while deleting..!"

                });
                return SucessResponse(emobj);
            }
            catch (Exception Ex)
            {
                return BadResponse(new { data = "", isSucessful = false, Errors = Ex.Message });
            }
        }


    }
}
