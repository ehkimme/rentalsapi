using System.ComponentModel.DataAnnotations;

namespace RentalsApi
{
    public partial class StaffList
    {
        [Key]
        public long? Id { get; set; }
        public byte[]? Name { get; set; }
        public string? Address { get; set; }
        public string? ZipCode { get; set; }
        public string? Phone { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public long? Sid { get; set; }
    }
}
