using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Comman
{
    public interface ISoftDeleteEntity
    {
        public bool IsDeleted { get; set; }
    }
}
