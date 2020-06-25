using GuildCars.Models.Tables;
using GuildCars.Models.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Interfaces
{
    public interface IVehicleRepository
    {
        List<Vehicles> GetAll();

        Vehicles GetById(int VehicleId);

        void Insert(Vehicles vehicles);

        void Update(Vehicles vehicles);
         
        void Delete(int VehicleId);
        IEnumerable<VehicleCondition> GetAllNew();
        IEnumerable<VehicleCondition> GetAllUsed();
        IEnumerable<FeaturedVehicle> GetAllFeatured();

        VehicleDetails GetVehicleDetails(int VehicleId);
        List<VehicleDetails> searchVehicles(SearchCarsQuery search);


    }
}
