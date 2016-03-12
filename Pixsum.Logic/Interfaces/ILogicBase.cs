using Pixsum.Entities;

namespace Pixsum.Logic.Interfaces
{
    public interface ILogicBase<TEntity> 
    {
        void Add(TEntity entity);
    }
}