using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.Common.Command
{
    public class CreateUserCommand
    {
        [Required(ErrorMessage = "Adı alanı gereklidir.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Soyadı alanı gereklidir.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "E-posta adresi gereklidir.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Telefon Numarası gereklidir.")]
        [RegularExpression("^0[5-7][0-9]{9}$", ErrorMessage = "Geçerli bir telefon numarası giriniz.")]
        [Phone(ErrorMessage = "Geçerli bir telefon numarası giriniz.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Şifre gereklidir.")]
        [MinLength(8, ErrorMessage = "Şifre en az 8 karakter olmalıdır.")]
        public string Password { get; set; }
    }

}
