using GuildCars.Models.Tables;
using GuildCars.Models.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Interfaces
{
    public interface IModelRepository
    {
        List<Model> GetAllByMakeId(int MakeId);
        List<Model> GetAll();
        Model GetByModelId(int ModelId);

        void Insert(Model model);

    }
}
