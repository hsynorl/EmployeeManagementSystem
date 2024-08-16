namespace EmployeeManagementSystem.Common.Command
{
    public class CreateUserDepartmentCommand
    {
        public Guid UserId { get; set; }
        public Guid DepartmentId { get; set; }
    }
}
