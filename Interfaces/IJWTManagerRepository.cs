using CRUD.Common;
using CRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.Interfaces
{
   public interface IJWTManagerRepository
    {
        Tokens Authenticate(AppUser users);   
    }
}
