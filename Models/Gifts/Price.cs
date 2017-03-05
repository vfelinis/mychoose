using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyChoose.Models
{
    public class Price
    {
        public int Id { get; set; }
        [Required]
        public int Value { get; set; }
        public List<Gift> GiftsPriceFrom { get; set; }
        public List<Gift> GiftsPriceTo { get; set; }
        public Price()
        {
            GiftsPriceFrom = new List<Gift>();
            GiftsPriceTo = new List<Gift>();
        }
    }
}
