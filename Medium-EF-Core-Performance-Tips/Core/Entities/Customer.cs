using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entity
{
    public class Customer : BaseEntity
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? City { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
