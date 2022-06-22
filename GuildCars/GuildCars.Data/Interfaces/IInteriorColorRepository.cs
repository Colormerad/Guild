﻿using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Interfaces
{
    public interface IInteriorColorRepository
    {
        List<InteriorColor> GetAll();
        InteriorColor GetById(int InteriorColorId);
    }
}