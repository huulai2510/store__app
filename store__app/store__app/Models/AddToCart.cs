using System;
using System.Collections.Generic;
using System.Text;

namespace store__app.Models
{
    class AddToCart
    {
        public double Price { get; set; }
        public int Qty { get; set; }
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
    }
}
