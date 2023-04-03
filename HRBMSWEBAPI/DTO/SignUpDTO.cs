using System.ComponentModel.DataAnnotations;

namespace HRBMSWEBAPI.DTO
{
    public class SignUpDTO
    {
        [Required]

        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        [EmailAddress] 
        public string Email { get; set;}

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }
    }
}
