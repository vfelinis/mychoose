using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyChoose.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        public string CategoryName { get; set; }
        public List<CategoryDetail> CategoryDetails { get; set; }
        public Category()
        {
            CategoryDetails = new List<CategoryDetail>();
        }
    }
}
