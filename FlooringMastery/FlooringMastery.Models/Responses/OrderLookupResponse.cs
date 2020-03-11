using System;
using System.Collections.Generic;
using System.Text;

namespace FlooringMastery.Models.Responses
{
    public class OrderLookupResponse : Response
    {
        public Order Order { get; set; }
    }
}
