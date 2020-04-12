using System.Collections.Generic;

namespace Repository.Entities
{
    public class User : BaseEntity
    {

        public User()
        {
            UserAuths = new HashSet<UserAuth>();
        }
        public string Name { get; set; }
        public string ExibitionName { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }

        public virtual ICollection<UserAuth> UserAuths { get; set; }
    }
}
