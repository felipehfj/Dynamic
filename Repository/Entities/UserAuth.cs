using System;

namespace Repository.Entities
{
    public class UserAuth : BaseEntity
    {
        public string Password { get; set; }
        public bool? IsActive { get; set; }
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
    }
}
