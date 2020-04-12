using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class UserModel : IGenericModel<UserModel>
    {
        public Guid Id { get; set; }
        public DateTime CreatedAtUtc { get; set; }
        public DateTime UpdatedAtUtc { get; set; }
        public string Name { get; set; }
        public string ExibitionName { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }

        public virtual List<UserAuthModel> UserAuths { get; set; }
    }
}
