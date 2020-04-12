using System;

namespace Domain.Models
{
    public class UserAuthModel : IGenericModel<UserAuthModel>
    {
        public Guid Id { get; set; }
        public DateTime CreatedAtUtc { get; set; }
        public DateTime UpdatedAtUtc { get; set; }
        public string Password { get; set; }
        public bool? IsActive { get; set; }
        public Guid UserId { get; set; }
        public virtual UserModel User { get; set; }
    }
}
