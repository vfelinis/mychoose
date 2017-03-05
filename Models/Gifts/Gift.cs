using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MyChoose.Models
{
    public class Gift
    {
        public int Id { get; set; }
        [Required]
        
        public string GiftName { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }
        [Required]
        public DateTime UpdateDate { get; set; }
        public Price PriceFrom { get; set; }
        public Price PriceTo { get; set; }
        public List<CategoryDetail> CategoryDetails { get; set; }

        public Gift()
        {
            CategoryDetails = new List<CategoryDetail>();
        }

    }
}
