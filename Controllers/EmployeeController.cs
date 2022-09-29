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

    public class EmployeeController : BaseController
    {

        private readonly IEmp _empRepo;
        private readonly ILogService _logService;
        public EmployeeController(IEmp empRepo, ILogService logService)
        {
            _empRepo = empRepo;
            _logService = logService;
        }
        //[HttpGet]
        //[ActionName("GetThirdAPI")]
        //public async Task<IActionResult> GetThirdAPIAsync()
        //{
        //    try
        //    {
        //        string Url = "https://mocki.io/v1/d4867d8b-b5d5-4a48-a4ab-79131b5809b8";
        //        HttpClient httpClient = new HttpClient();

        //        Uri uri = new Uri(Url);

        //        var request = new HttpRequestMessage()
        //        {
        //            Content = null,
        //            RequestUri = uri,
        //            Method = HttpMethod.Get,

        //        };

        //        //request.Headers.Add("Authorization", TamaraSecretKey);
        //        var response = await httpClient.SendAsync(request);
        //        var respnoseText = await response.Content.ReadAsStringAsync();
        //        var data = JsonConvert.DeserializeObject<List<Mapper>>(respnoseText);

        //        List<Mapper> lst = new List<Mapper>();
        //        lst.Add(new Mapper() { name = "Shahzad", city = "Karachi" });
        //        lst.Add(new Mapper() { name = "Aqib", city = "Lahore" });
        //        lst.Add(new Mapper() { name = "Salim", city = "Peshawar" });
        //        lst.Add(new Mapper() { name = "Jamil", city = "Karachi" });
        //        var data1 = JsonConvert.SerializeObject(lst);

        //        return SucessResponse(data);

        //    }
        //    catch (Exception Ex)
        //    {

        //        return BadRequest(new { data = "", isSucessful = false, Errors = Ex.Message });
        //    }
        //}


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
                    Description = "Track User Activity"

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

public class Mapper
{
    public string name { get; set; }
    public string city { get; set; }
}