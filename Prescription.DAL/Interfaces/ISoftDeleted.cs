using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prescription.DAL.Interfaces
{
    public interface ISoftDeleted
    {
        bool Deleted { get; set; }
    }
}
