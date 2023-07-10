using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Order : BaseEntity
    {
        public string? Name { get; set; }
        public string? Detail { get; set;}
        public int Code { get; set;}
    }
}
