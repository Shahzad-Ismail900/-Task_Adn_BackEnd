
using CRUD.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.Interfaces
{
    public interface ILogService
    {
        ApiResponse CreateLog(LogUserActivity obj);


    }
}
