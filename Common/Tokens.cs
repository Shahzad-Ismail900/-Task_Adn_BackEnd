using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.Common
{
    public class Tokens
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }

        public int UserId { get; set; }
    }
}
