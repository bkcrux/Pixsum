using System;

namespace Pixsum.Entities.Interfaces
{
    public interface IAccount: IEntityBase, IEntityAuditable
    {
        string AccountName { get; set; }
        string SubDomain { get; set; }
    }
}