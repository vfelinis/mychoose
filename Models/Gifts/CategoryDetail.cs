using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyChoose.Models
{
    public class CategoryDetail
    {
        public int Id { get; set; }
        public Category Category { get; set; }
        public Gift Gift { get; set; }
    }
}
