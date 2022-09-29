using System;
using System.Collections.Generic;

namespace CRUD.Models
{
    public partial class LogUserActivity
    {
        public int Id { get; set; }
        public string FormName { get; set; }
        public string Action { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public DateTime? LogTime { get; set; }
    }
}
