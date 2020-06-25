using GuildCars.Data.Interfaces;
using GuildCars.Data.ADO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GuildCars.Data;

namespace GuildCars.Factories
{
    public static class VehicleRepositoryFactory
    {
        public static IVehicleRepository GetRepository() 
        {
            switch(Settings.GetRepositoryType())
            {
                case "ADO":
                    return new VehicleRepositoryADO();
                default:
                    throw new Exception("Could not find valid Repository Type configuration value");
            }

        }
    }
}