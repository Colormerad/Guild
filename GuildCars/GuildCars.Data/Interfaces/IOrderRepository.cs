using GuildCars.Models.Queries;
using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Interfaces
{
    public interface IOrderRepository
    {
        List<Orders> GetAll();

        Orders GetById(int OrderId);

        void Insert(Orders orders);

        void Update(Orders orders);

        void Delete(int OrderId);

        List<SalesResults> searchOrders(SearchOrdersQuery search);

    }
}
