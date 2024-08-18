using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.Common.Command
{
    public class DeleteUserCommand
    {
        [Required(ErrorMessage = "User Id alanı gereklidir.")]

        public Guid UserId { get; set; }

    }

}
