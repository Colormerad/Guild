using System;
using System.Collections.Generic;
using System.Text;

namespace FlooringMastery.Models.Responses
{
    public class OrdersLookupResponse : Response
    {
        public List <Order> Orders { get; set; }
    }
}

