﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pixsum.Data.Interfaces
{
    public interface IDbFactory : IDisposable
    {
        PixsumContext Initialize();
    }
}
