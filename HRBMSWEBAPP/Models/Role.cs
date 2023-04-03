using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Identity;

namespace HRBMSWEBAPP.Models
{
    public class Role : IdentityUser
    {
        [DisplayName("Role ID")]
        [Key]
        public int Id { get; set; }

        [DisplayName("Role")]
        [Required]
        public string Role_Name { get; set; }

        //[ValidateNever]
        //public ICollection<User> Users { get; set; }
    }
}
