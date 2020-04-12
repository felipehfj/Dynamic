using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class UserAddModel : IGenericModel<UserAddModel>
    {
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        [MaxLength(30)]
        public string ExibitionName { get; set; }
        [Required]
        [MaxLength(20)]
        public string Login { get; set; }
        [Required]
        [EmailAddress]
        [MaxLength(255)]
        public string Email { get; set; }
    }
}
