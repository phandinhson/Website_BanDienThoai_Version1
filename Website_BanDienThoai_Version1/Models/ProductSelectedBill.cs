using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Website_BanDienThoai_Version1.Models
{
    public class ProductSelectedBill
    {
        public int Id { get; set; }
        [ForeignKey("BillId")]
        public int BillId { get; set; }
        public virtual Bill Bill { get; set; }
        [ForeignKey("ProductId")]
        public int ProductId { get; set; }
        public virtual Products Products { get; set; }
    }
}
