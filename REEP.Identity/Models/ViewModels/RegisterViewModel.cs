using System.ComponentModel.DataAnnotations;

namespace REEP.Identity.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        public string Usename { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        public string ReturnUrl { get; set; }
    }
}
