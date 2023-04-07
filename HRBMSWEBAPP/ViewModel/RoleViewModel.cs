using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRBMSWEBAPP.ViewModel
{
    public class RoleViewModel
    {
        [DisplayName("Role ID")]
        [Key]
        public Guid Id { get; set; }

        [DisplayName("Role")]
        [Required]
        public string Name { get; set; }

        [ValidateNever]
        [NotMapped]
        public IEnumerable<SelectListItem> RoleList { get; set; }
    }
}
