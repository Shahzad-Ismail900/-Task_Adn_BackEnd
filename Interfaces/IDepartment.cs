
using CRUD.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.Interfaces
{
    public interface IDepartment
    {

        DataTable GetDeptList();

        DataTable GetDeptById(int DeptId);
        ApiResponse SaveDept(Department obj);

        ApiResponse DeleteDept(int Id);
    }
}
