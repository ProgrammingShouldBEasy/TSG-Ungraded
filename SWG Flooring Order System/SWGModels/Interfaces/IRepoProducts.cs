﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWGModels.Interfaces
{
    public interface IRepoProducts
    {
        List<Product> LoadProducts();
    }
}
