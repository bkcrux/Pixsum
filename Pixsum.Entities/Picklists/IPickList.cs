using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pixsum.Entities.Picklists
{
    interface IPickList
    {
        int Id { get; set; }
        string Value { get; set; }
        string Description { get; set; }

    }
}
