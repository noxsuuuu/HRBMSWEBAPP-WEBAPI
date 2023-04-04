using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

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
    }
}
