using ITMApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITMApp.DBContext
{
    public class EFDBRepository : IDBRepository
    {
        private EFDBContext context = new EFDBContext();

        public IEnumerable<status> status { get {  return context.status; } }
        public IEnumerable<_switch> switches { get { return context.switches;  } }

        public void SaveStatus(status status)
        {
            if (status.statusID == 0)
            {
                context.status.Add(status);
                context.SaveChanges();
            }
        }

    }
}