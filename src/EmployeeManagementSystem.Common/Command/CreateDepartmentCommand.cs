using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.Common.Command
{
    public class CreateDepartmentCommand
    {
        [Required(ErrorMessage = "Departman adı alanı gereklidir.")]
        public string Name { get; set; }
    }
}
