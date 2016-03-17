using Pixsum.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pixsum.Entities
{
    public class BlogContent : IEntityBase, IEntityAuditable
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public string Caption { get; set; }
        public string Tags { get; set; }

        //this will be the GUID in the 3rd party file system
        public Guid FileGUID { get; set; }
        public FileStorageService PL_FileStorageService { get; set; }
        public FileType PL_FileType { get; set; }
        public string FileName { get; set; }
        public string FileExtension { get; set; }
        public int FileSize { get; set; }
        public int CreatedUserId { get; set; }
        public int UpdatedUserId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public virtual User CreatedUser { get; set; }
        public virtual User UpdatedUser { get; set; }

    }

    public enum FileType
    {
        Image = 1,
        Video = 2
    }

    public enum FileStorageService
    {
        Azure = 1,
        AWS_S3 = 2
    }
}
