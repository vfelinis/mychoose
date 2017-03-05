using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyChoose.ViewModels
{
    public class GiftView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public int PriceFrom { get; set; }
        public int PriceTo { get; set; }
        public List<string> Categories { get; set; }
    }
}
