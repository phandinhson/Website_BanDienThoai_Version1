using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Website_BanDienThoai_Version1.Models
{
    public class Bill
    {
        public int Id { get; set; }
        public int? TotalPrice { get; set; }
        [ForeignKey("CustomerId")]
        public int CustomerId { get; set; }
        public DateTime? DateBill { get; set; }

        public virtual Customers Customers { get; set; }
    }
}
