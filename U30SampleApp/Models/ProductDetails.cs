using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace U30SampleApp.Models
{
    public class ProductDetails
    {
        public int PhoneID { get; set; }

        public string PhoneName { get; set; }

        public string Image { get; set; }

        public string Colour { get; set; }

        public string Storage { get; set; }

        public decimal Price { get; set; }
    }
}