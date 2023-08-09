using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace edTechSpark.Models
{
    public class RazorPayOrderModel
    {
        public decimal GrandTotal { get; set; }
        public string Currency { get; set; }
        public string Receipt { get; set; }
    }
}
