
using CRUD.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.Interfaces
{
    public interface IEmp
    {

        DataTable GetEmpList();

        DataTable GetEmpById(int EmpId);

        DataTable GetAllEmployeeType();

        DataTable GetAllEmployeesStatus();
        ApiResponse SaveEmp(Employee obj);

        ApiResponse DeleteEmp(int Id);
    }
}
