using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pixsum.Models
{
    public class AccountModel
    {
        public int Id { get; set; }

        public string AccountName { get; set; }
        public string SubDomain { get; set; }

        public int CreatedUserId { get; set; }
        public int UpdatedUserId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}