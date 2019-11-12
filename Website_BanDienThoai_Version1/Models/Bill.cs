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
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public Users Users { get; set; }
        public int TotalPrice { get; set; }
        public DateTime BillDate { get; set; }

        public virtual ICollection<Bill_Details> Bill_Details { get; set; }
    }
}
