using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace edTechSpark.Models
{
    public class ReceiptModel
    {
        public string PaymentId { get; set; }
        public string Currency { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
        public decimal GrandTotal { get; set; }
    }
}
