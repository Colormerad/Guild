using System;
using System.Collections.Generic;
using System.Text;
using FlooringMastery.Models;

namespace FlooringMastery.Models.Interfaces
{
    public interface IStateTaxRepository
    {
        List<State> ReadAll();

        State ReadByStateAbbreviation(Order order);

    }
}
