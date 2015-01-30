using ITMApp.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ITMApp.Controllers
{
    public class DowntimeController : Controller
    {
        private IDBRepository repository = new EFDBRepository();

        public ViewResult Index(DateTime? dateFirst, DateTime? dateLast, int switchID = 1)
        {
            ViewBag.Switches = new SelectList(repository.switches, "switchID", "Name"); //fill selection options

            var _switch = (from r in repository.switches where r.switchID == switchID select r).FirstOrDefault();

            dateFirst = (!dateFirst.HasValue ? DateTime.Now : dateFirst);
            dateLast = (!dateLast.HasValue ? DateTime.Now.AddDays(-10) : dateLast);

            var FilteredStatuses = from s in _switch.status
                                   where s.datetime > dateFirst && s.datetime < dateLast
                                   select s;

            TimeSpan span = new TimeSpan();
            DateTime lastDownDate = new DateTime();
            List<TimeSpan> ts = new List<TimeSpan>();

            foreach (var s in FilteredStatuses)
            {
                if (s.action == "-1")
                {
                    lastDownDate = s.datetime;
                }
                else
                {
                    var h = TimeSpan.FromTicks(s.datetime.Subtract(lastDownDate).Ticks);
                    ts.Add(h);
                }
            }
            TimeSpan total = TimeSpan.FromTicks(ts.AsEnumerable().Sum(t=>t.Ticks));
            return View();
        }

    }
}
