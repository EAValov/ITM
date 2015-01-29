using ITMApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITMApp.DBContext
{
   public interface IDBRepository
    {
        IEnumerable<status> status { get; }
        IEnumerable<_switch> switches { get; }
        void SaveStatus(status status);
    }
}
