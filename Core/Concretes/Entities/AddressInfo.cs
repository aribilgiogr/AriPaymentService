using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Concretes.Entities
{
    public class AddressInfo
    {
        public int Id { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? PostalCode { get; set; }
        public string? Country { get; set; }

        [ForeignKey("Customer")]
        public string CustomerId { get; set; } = null!;
        public virtual CustomerInfo? Customer { get; set; }
    }

    public class CustomerInfo
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string? Email { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Phone { get; set; }
        public virtual ICollection<AddressInfo> Addresses { get; set; } = [];
    }
}
