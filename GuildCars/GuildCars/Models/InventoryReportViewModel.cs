using GuildCars.Models.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuildCars.Models
{
    public class InventoryReportViewModel
    {
        public List<NewInventoryReportQuery> newInventoryReports { get; set; }
        public List<UsedInventoryReportQuery> usedInventoryReports { get; set; }
    }
}