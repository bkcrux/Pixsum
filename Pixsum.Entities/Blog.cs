using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pixsum.Entities 

{
    public class Blog : IEntityBase, IEntityAuditable
    {
        public Blog()
        {
            BlogContents = new List<BlogContent>();
            BlogComments = new List<BlogComment>();
        }

        public int Id { get; set; }
        public int AccountId { get; set; }
        public string Title { get; set; }
        public DateTime BlogDate { get; set; }
        public string Description { get; set; }
        public string Tags { get; set; }
        public bool IsPublic { get; set; }
        public int CreatedUserId { get; set; }
        public int UpdatedUserId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public virtual User CreatedUser { get; set; }
        public virtual User UpdatedUser { get; set; }

        public virtual ICollection<BlogContent> BlogContents { get; set; }
        public virtual ICollection<BlogComment> BlogComments { get; set; }


    }
}
