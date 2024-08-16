namespace EmployeeManagementSystem.Entities.Entities
{
    public class Department:BaseEntity {

        public string Name { get; set; }
        public ICollection<UserDepartment> UserDepartments{ get; set; }
    }
}
