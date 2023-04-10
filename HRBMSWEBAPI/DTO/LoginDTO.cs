using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace HRBMSWEBAPI.DTO
{
    public class LoginDTO
    {
        [Required]
        [EmailAddress]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
    }
}
