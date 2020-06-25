using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuildCars.Models.Queries;

namespace GuildCars.Data.Interfaces
{
    public interface IInventoryReportRepository
    {
        List<NewInventoryReportQuery> GetAllNew();
        List<UsedInventoryReportQuery> GetAllUsed();
    }
}
