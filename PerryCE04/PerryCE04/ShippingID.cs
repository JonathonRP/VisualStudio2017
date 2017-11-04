using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerryCE04
{
    class ShippingID
    {
        public int Shipping_id { get; set; }
        public string Shipping_code { get; set; }
        public string Routing { get; set; }

        public ShippingID(int shipping_id, string shipping_code, string routing)
        {
            Shipping_id = shipping_id;
            Shipping_code = shipping_code;
            Routing = routing;
        }
    }
}
