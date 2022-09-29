using CRUD.Common;
using CRUD.Interfaces;
using CRUD.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.Services
{
    public class EmployeeRepo : IEmp
    {
        private readonly EDMSContext _context;
        public EmployeeRepo(EDMSContext context)
        {
            _context = context;
        }

        public ApiResponse DeleteEmp(int Id)
        {
            try
            {
                var obj = _context.Employee.Where(a => a.EmpId == Id).FirstOrDefault();
                if (obj != null)
                    _context.Employee.Remove(obj);
                _context.SaveChanges();
                return (new ApiResponse { data = "Deleted Successfully", isSucessful = true });
            }
            catch (Exception)
            {

                throw;
            }
          
        }

        public DataTable GetEmpList()
        {
            try
            {
                DataAccessLayer dac = new DataAccessLayer();
                var obj = dac.ExecuteSP("sp_GetAllEmployee");  
                return obj;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public DataTable GetEmpById(int EmpId)
        {
            try
            {
                DataAccessLayer dac = new DataAccessLayer();
                string[] parameters = { "EmpId" };
                var obj = dac.ExecuteSPWithParams("sp_GetEmployeeById", parameters, EmpId);
                return obj;
            }
            catch (Exception)
            {

                throw;
            }

        }



        public ApiResponse SaveEmp(Employee obj)
        {
            try
            {
                Employee empobj = null;

                empobj = obj.EmpId == 0 ? new Employee() : _context.Employee
                .FirstOrDefault(e => e.EmpId == obj.EmpId);

                empobj.Code = obj.Code;
                empobj.Name = obj.Name;
                empobj.ContactNo = obj.ContactNo;
                empobj.Email = obj.Email;
                empobj.DeptId = obj.DeptId;
                empobj.EmpTypeId = obj.EmpTypeId;
                empobj.EmpStatusId = obj.EmpStatusId;
                if (obj.EmpId == 0)
                {
                    empobj.CreatedBy = 1;
                    empobj.CreatedDate = DateTime.Now;
                    _context.Employee.Add(empobj);
                }
                else
                {
                    empobj.ModifiedBy = 1;
                    empobj.ModifiedDate = DateTime.Now;
                }

                _context.SaveChanges();

                return (new ApiResponse { data = "Saved Successfully", isSucessful = true });
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public DataTable GetAllEmployeeType()
        {
            try
            {
                DataAccessLayer dac = new DataAccessLayer();
                var obj = dac.ExecuteSP("sp_GetAllEmployeeType");
                return obj;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable GetAllEmployeesStatus()
        {
            try
            {
                DataAccessLayer dac = new DataAccessLayer();
                var obj = dac.ExecuteSP("sp_GetAllEmployeeStatus");
                return obj;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
