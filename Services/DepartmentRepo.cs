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
    public class DepartmentRepo : IDepartment
    {
        private readonly EDMSContext _context;
        public DepartmentRepo(EDMSContext context)
        {
            _context = context;
        }

        public ApiResponse DeleteDept(int DeptId)
        {
            try
            {
                var obj = _context.Department.Where(a => a.DeptId == DeptId).FirstOrDefault();
                if (obj != null)
                    _context.Department.Remove(obj);
                _context.SaveChanges();
                return (new ApiResponse { data = "Deleted Successfully", isSucessful = true });
            }
            catch (Exception)
            {

                throw;
            }
          
        }

        public DataTable GetDeptList()
        {
            try
            {
                DataAccessLayer dac = new DataAccessLayer();
                var obj = dac.ExecuteSP("sp_GetAllDept");
                return obj;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public DataTable GetDeptById(int DeptId)
        {
            try
            {
                DataAccessLayer dac = new DataAccessLayer();
                string[] parameters = { "DeptId" };
                var obj = dac.ExecuteSPWithParams("sp_GetDeptById", parameters, DeptId);
                return obj;
            }
            catch (Exception)
            {

                throw;
            }

        }



        public ApiResponse SaveDept(Department obj)
        {
            try
            {
                Department deptobj = null;

                deptobj = obj.DeptId == 0 ? new Department() : _context.Department
                .FirstOrDefault(e => e.DeptId == obj.DeptId);

                deptobj.Code = obj.Code;
                deptobj.Name = obj.Name;

                if (obj.DeptId == 0)
                {
                    deptobj.CreatedBy = obj.CreatedBy;
                    deptobj.CreatedDate = DateTime.Now;
                    _context.Department.Add(deptobj);
                }
                else
                {
                    deptobj.ModifiedBy = obj.CreatedBy;   //both are managed by single property
                    deptobj.ModifiedDate = DateTime.Now;
                }
                _context.SaveChanges();

                return (new ApiResponse { data = "Saved Successfully", isSucessful = true });
            }
            catch (Exception)
            {

                throw;
            }
          
        }
    }
}
