using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Website_BanDienThoai_Version1.Models
{
    public class Bill_Details
    {
       
        public int ProductId { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        [Key]
        public int BillId { get; set; }
        public virtual Bill Bill { get; set; } 
        public virtual Products Product { get; set; }
    }
}
