using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
   public class About
    {
        public int AboutID { get; set; }
        [StringLength(100)]
        public string SmallDetail { get; set; }
        [StringLength(1000)]
        public string BigDetail { get; set; }
        [StringLength(150)]
        public string ImageUrlOne { get; set; }
        [StringLength(150)]
        public string ImageUrlTwo { get; set; }
    }
}
