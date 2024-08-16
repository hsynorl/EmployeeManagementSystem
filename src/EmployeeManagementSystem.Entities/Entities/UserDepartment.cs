namespace EmployeeManagementSystem.Entities.Entities
{
    public class UserDepartment:BaseEntity {
        public Guid DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        public virtual User User { get; set; }  
    }
}
