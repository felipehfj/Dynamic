using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class LoginModel : IGenericModel<LoginModel>
    {
        [Required]
        [MaxLength(20)]
        public string Login { get; set; }
        public string Password { get; set; }
        public string Audience { get; set; }
    }
}
