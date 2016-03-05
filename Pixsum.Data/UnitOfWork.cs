using Pixsum.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pixsum.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbFactory _dbFactory;
        private PixsumContext _dbcontext;

        public UnitOfWork(IDbFactory factory)
        {
            _dbFactory = factory;
            _dbcontext = _dbFactory.Initialize();
        }

        public void Save()
        {
            _dbcontext.SaveChanges();
        }

    }
}
