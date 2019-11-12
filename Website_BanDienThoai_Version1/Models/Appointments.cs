using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Website_BanDienThoai_Version1.Models
{
    public class Appointments
    {
        public int Id { get; set; }
        public DateTime AppointmentsDate { get; set; }
        public string CustomerName { get; set; }
        public string CustomerNumberPhone { get; set; }
        public bool isConfirmed { get; set; }

    }
}
