using System.ComponentModel.DataAnnotations;

namespace HRBMSWEBAPI.DTO
{
    public class UserDTO
    {
        [Required]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        public UserDTO() { }
        public UserDTO(int id, string firstName, string lastName, string email, string phone, string address)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Phone = phone;
            Address = address;
        }
    }
}
