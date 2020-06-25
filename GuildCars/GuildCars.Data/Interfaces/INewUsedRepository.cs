using GuildCars.Models.Tables;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Interfaces
{
    public interface INewUsedRepository
    {
        List<NewUsed> GetAll();
        NewUsed GetById(int NewUsedId);
    }
}
