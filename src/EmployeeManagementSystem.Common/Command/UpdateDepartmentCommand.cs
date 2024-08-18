using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.Common.Command
{
    public class UpdateDepartmentCommand
    {
        [Required(ErrorMessage = "Departman Id alanı gereklidir.")]

        public Guid DepartmentId { get; set; }
        [Required(ErrorMessage = "Departman adı alanı gereklidir.")]

        public string Name { get; set; }
    }
}
