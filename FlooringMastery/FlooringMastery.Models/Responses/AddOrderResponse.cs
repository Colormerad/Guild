using System;
using System.Collections.Generic;
using System.Text;

namespace FlooringMastery.Models.Responses
{
    public class AddOrderResponse : Response
    {
        public Order Order { get; set; }
    }
}
