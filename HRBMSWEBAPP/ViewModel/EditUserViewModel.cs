using System.ComponentModel.DataAnnotations;

namespace HRBMSWEBAPP.ViewModel
{
    public class EditUserViewModel
    {
        public string Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public IList<string> Roles { get; set; }

    }
}
