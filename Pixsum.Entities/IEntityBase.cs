using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pixsum.Entities
{
    public interface IEntityBase
    {
        int Id { get; set; }
        int CreatedUserId { get; set; }
        int UpdatedUserId { get; set; }
        DateTime CreatedDate { get; set; }
        DateTime UpdatedDate { get; set; }
    }
}
