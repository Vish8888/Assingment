using System.ComponentModel.DataAnnotations;

namespace MVCCore.Models
{
    public class LoginModel
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required(ErrorMessage ="Enter Email Address")]
        [DataType(DataType.EmailAddress)]
        public string Emailed { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string UserRole { get; set; }
        
        public string IsActive { get; set; }






    }
}
