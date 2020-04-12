using System;

namespace Domain.Models.Auth
{
    public class UserTokenModel
    {
        public Guid Id { get; set; }        
        public string Name { get; set; }
        public string ExibitionName { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Audience { get; set; }
    }
}
