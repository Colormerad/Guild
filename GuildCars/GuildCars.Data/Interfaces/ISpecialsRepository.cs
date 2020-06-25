using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Interfaces
{
    public interface ISpecialsRepository
    {
        List<Specials> GetAll();
        Specials GetById(int SpecialId);

        void Insert(Specials specials);

        void Delete(int SpecialId);
    }
}
