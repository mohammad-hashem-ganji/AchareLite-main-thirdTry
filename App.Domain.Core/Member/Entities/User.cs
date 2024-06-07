using App.Domain.Core.Adress.Entities;

namespace App.Domain.Core.Member.Entities
{
    public abstract class User
    {
        public int Id { get; set; }
        public string NCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mobile { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdate { get; set; }
        public bool IsDeleted { get; set; }
        public int Gender { get; set; }
        public Address Address { get; set; }
    }
}
