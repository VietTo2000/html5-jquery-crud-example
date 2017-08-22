using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_Demo.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public DateTime IntroductionDate { get; set; }
        public string Url { get; set; }
        public int Sale { get; set; }
    }
}