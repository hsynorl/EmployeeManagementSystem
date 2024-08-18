using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.Common.Command
{
    public class DeleteDepartmentCommand
    {
        [Required(ErrorMessage = "Departman Id alanı gereklidir.")]

        public Guid DepartmentId { get; set; }
    }
}
