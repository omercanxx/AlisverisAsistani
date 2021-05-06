using System;
using System.Collections.Generic;
using System.Text;

namespace BitirmeProjesi.Core.Entities
{
    public class Store
    {
        public Store()
        {
            IsActive = true;
            CreatedOn = DateTime.Now;
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public double Longtitude { get; set; }
        public double Latitude { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public ICollection<Product_Store> Product_Store { get; set; }
        public ICollection<Scan> Scans { get; set; }
    }
}
