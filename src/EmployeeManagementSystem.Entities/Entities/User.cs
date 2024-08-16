using EmployeeManagementSystem.Common.Enums;

namespace EmployeeManagementSystem.Entities.Entities
{
    public class User:BaseEntity {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public UserType UserType { get; set; }
        public virtual UserDepartment UserDepartment{ get; set; }

    }
}
