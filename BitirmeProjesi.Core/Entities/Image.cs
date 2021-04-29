using System;
using System.Collections.Generic;
using System.Text;

namespace BitirmeProjesi.Core.Entities
{
    public class Image
    {
        public Image()
        {
            IsActive = true;
            CreatedOn = DateTime.Now;
        }
        public Guid Id { get; set; }
        public int Sort { get; set; }
        public string Path { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public ICollection<Product_Image> Product_Image { get; set; }
    }
}
