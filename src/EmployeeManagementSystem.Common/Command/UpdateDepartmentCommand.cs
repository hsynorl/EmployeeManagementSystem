namespace EmployeeManagementSystem.Common.Command
{
    public class UpdateDepartmentCommand
    {
        public Guid DepartmentId { get; set; }
        public string Name { get; set; }
    }
}
