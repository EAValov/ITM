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
        private IDBRepository repository;

        public DowntimeController(IDBRepository repo)
        {
            this.repository = repo;
        }


        public ActionResult Index(DateTime? dateFirst, DateTime? dateLast, int switchID = 1)
        {
            ViewBag.Switches = new SelectList(repository.switches, "switchID", "Name"); //fill selection options

            var _switch = (from r in repository.switches where r.switchID == switchID select r).FirstOrDefault();

            if (dateFirst > dateLast)
            {
                TempData["ErrorMessage"] = "Некорректный ввод - датас должна быть меньше даты до";
                return RedirectToAction("Index");
            }

            dateFirst = (!dateFirst.HasValue ? DateTime.Now : dateFirst);
            dateLast = (!dateLast.HasValue ? DateTime.Now.AddDays(-10) : dateLast);

            var FilteredStatuses = from s in _switch.status
                                   where s.datetime >= dateFirst && s.datetime <= dateLast
                                   select s;

            DateTime lastDownDate = new DateTime();
            List<TimeSpan> ts = new List<TimeSpan>(); //this will hold all downtime timespans 

            FilteredStatuses.DefaultIfEmpty(null);

            foreach (var s in FilteredStatuses)
            {
                if (s.action == "-1")
                {
                    lastDownDate = s.datetime; //save last down date to next iteration(it will be +1)
                }
                else if (lastDownDate == new DateTime()) { continue; } //if this is first iteration - continue. we don't need last date as 000000....
                else 
                {
                    var h = TimeSpan.FromTicks(s.datetime.Subtract(lastDownDate).Ticks); //counting timespan
                    ts.Add(h); //and add it to collection
                }
            }

            //check for last action. if it's down - we use datelast to count final timespan
            if (!FilteredStatuses.Any() || FilteredStatuses.LastOrDefault().action == "-1")
            {
                var p = TimeSpan.FromTicks(dateLast.Value.Subtract(lastDownDate).Ticks);
                ts.Add(p);
            }

            TimeSpan total = (lastDownDate != new DateTime()) ? TimeSpan.FromTicks(ts.AsEnumerable().Sum(t=>t.Ticks)) : new TimeSpan(); // if there was no last down, display 000000 date

            ViewBag.ReturnString = string.Format("C {0} по {1}, {2} был в состоянии DOWN в течении {3} дней {4} часов {5} минут и {6} секунд", dateFirst, dateLast, _switch.Name, total.Days, total.Hours, total.Minutes, total.Seconds);

            return View();
        }

    }
}
