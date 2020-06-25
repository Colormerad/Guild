using GuildCars.Factories;
using GuildCars.Models.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Web.Http;
using GuildCars.Models.Tables;

namespace GuildCars.Controllers
{
   
    public class SearchAPIController : ApiController
    {
        [Route("vehicleapi/search/")]
        [AcceptVerbs("POST")]
        public IHttpActionResult SearchNewCars(SearchCarsQuery query)
        {
            List<VehicleDetails> result = new List<VehicleDetails>();
            var repo = VehicleRepositoryFactory.GetRepository();

            result = repo.searchVehicles(query);
            return Ok(result);
        }


        [Route("orderapi/search/")]
        [AcceptVerbs("POST")]

        public IHttpActionResult SearchOrderResults(SearchOrdersQuery query)
        {

            List<SalesResults> results = new List<SalesResults>();
            var repo = OrdersRepositoryFactory.GetRepository();

            if (query.UserName.ToUpper() == "ALL")
            {
                query.UserName = null;
            }

            results = repo.searchOrders(query);
            return Ok(results);
        }

        [Route("Modelapi/search/")]
        [AcceptVerbs("POST")]
        public IHttpActionResult modelForm(Make query)
        {
            List<Model> result = new List<Model>();
            var repo = ModelsRepositoryFactory.GetRepository();

            result = repo.GetAllByMakeId(query.MakeId);
            return Ok(result);
        }

        [Route("vehicleapi/add/")]
        [AcceptVerbs("POST")]
        public IHttpActionResult addVehicle(Vehicles vehicle)
        {
            var repo = VehicleRepositoryFactory.GetRepository();

            repo.Insert(vehicle);
            return Ok();
        }
    }
}