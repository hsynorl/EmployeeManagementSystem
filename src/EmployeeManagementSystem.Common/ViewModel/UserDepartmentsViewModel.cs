using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Common.ViewModel
{
    public class UserDepartmentsViewModel
    {
        public Guid UserId { get; set; }
        public Guid DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
