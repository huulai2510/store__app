using System;
using System.Collections.Generic;
using System.Text;

namespace store__app.Models
{
    class Order
    {
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int OrderDetail { get; set; }
        public int UserId { get; set; }
    }
}
