using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pixsum.Entities
{
    public class BlogUser : IEntityBase, IEntityAuditable
    {
        public int Id { get; set; }
        
        public int BlogId { get; set; }
        public int UserId { get; set; }

        public int CreatedUserId { get; set; }
        public int UpdatedUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public virtual User CreatedUser { get; set; }
        public virtual User UpdatedUser { get; set; }

    }
}
