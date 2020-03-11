using FlooringMastery.Models;
using FlooringMastery.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FlooringMastery.Data
{

   public class StateTaxRepositoryFile : IStateTaxRepository
    {
        public List<State> ReadAll()
        {
            string path = @"C:\Data\Taxes.txt";
            char delimiter = ',';
            List<State> states = new List<State>();
            

            using (StreamReader reader = new StreamReader(path))
            {
                string[] rows = File.ReadAllLines(path);
                for (int i = 1; i < rows.Length; i++)
                {
                    State state = new State();
                    string[] columns = rows[i].Split(delimiter);

                    state.StateAbbreviation = columns[0];
                    state.StateName = columns[1];
                    state.TaxRate = Convert.ToDecimal(columns[2]);
                    states.Add(state);
                }
                return states;
            }
        }

        public State ReadByStateAbbreviation(Order order)
        {
            State state = new State();
            List<State> states = ReadAll();
            state = states.Where(x => x.StateAbbreviation == order.State).FirstOrDefault();
            return state;
        }
    }
}