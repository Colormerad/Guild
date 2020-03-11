using System;
using System.Collections.Generic;
using System.Text;

namespace FlooringMastery.Models.Responses
{
    public class RemoveOrderResponse : Response
    {
        public Order Order { get; set; }
    }
}
