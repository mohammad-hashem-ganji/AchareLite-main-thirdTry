using App.Domain.Core.Member.Entities;

namespace App.Domain.Core.Adress.Entities
{
    public class Address
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
    }
}
