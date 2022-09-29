using System;
using System.Collections.Generic;

namespace CRUD.Models
{
    public partial class Employee
    {
        public int EmpId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int? DeptId { get; set; }
        public int? EmpTypeId { get; set; }
        public int? EmpStatusId { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual Department Dept { get; set; }
        public virtual EmployeeStatus EmpStatus { get; set; }
        public virtual EmployeeType EmpType { get; set; }
    }
}
