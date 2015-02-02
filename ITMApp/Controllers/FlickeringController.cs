using ITMApp.DBContext;
using ITMApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ITMApp.Controllers
{
    public class FlickeringController : Controller
    {
        private IDBRepository repository = new EFDBRepository();

        public ActionResult Index(DateTime? dateFirst, DateTime? dateLast)
        {
            List<_switch> Flickers = new List<_switch>();

            dateFirst = (!dateFirst.HasValue ? DateTime.Now : dateFirst);
            dateLast = (!dateLast.HasValue ? DateTime.Now.AddDays(-10) : dateLast);

            foreach (_switch sw in repository.switches)
            {
                var FilteredStatuses = from s in sw.status
                                   where s.datetime >= dateFirst && s.datetime <= dateLast
                                   orderby s.datetime ascending
                                   select s;

                if (FilteredStatuses.Count() >= 10)
                {
                    for (int i = 0; i < FilteredStatuses.Count(); i++)
                    {
                        //select ten statuses and count timespan of min and max date
                        var Statuses = FilteredStatuses.Select(j => j.datetime).Skip(i).Take(10);
                        var StatusesTimeSpan = TimeSpan.FromTicks(Statuses.Max().Subtract(Statuses.Min()).Ticks);

                        //if sum of timespans less than 10s and it's more than 10
                        if (StatusesTimeSpan.Ticks < TimeSpan.FromSeconds(10).Ticks && Statuses.Count() >= 10)
                        {
                            Flickers.Add(sw);
                        }
                    }
                }
            }

            if (!Flickers.Any()) { TempData["ErrorMessage"] = "No flickering commutators found"; }

            return View(Flickers);
        }
    }
}
