namespace EmployeeManagementSystem.Common.Command
{
    public class UpdateUserDepartmentCommand
    {
        public Guid UserId { get; set; }
        public Guid DepartmentId { get; set; }
    }
}
