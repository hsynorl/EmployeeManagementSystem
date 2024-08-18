using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.Common.Command
{
    public class CreateUserDepartmentCommand
    {
        [Required(ErrorMessage = "User Id alanı gereklidir.")]

        public Guid UserId { get; set; }
        [Required(ErrorMessage = "Departman Id alanı gereklidir.")]

        public Guid DepartmentId { get; set; }
    }
}
