using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.Common.Command
{
    public class UpdateUserDepartmentCommand
    {
        [Required(ErrorMessage = "User Id alanı gereklidir.")]

        public Guid UserId { get; set; }
        [Required(ErrorMessage = "Departman Id alanı gereklidir.")]

        public Guid DepartmentId { get; set; }
    }
}
