using ITMApp.DBContext;
using ITMApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ITMApp.Controllers
{
    public class StatusController : Controller
    {
        private IDBRepository repository = new EFDBRepository();

        public ViewResult Index(DateTime? date)
        {
            //if date not set we get now
            date = (!date.HasValue ? DateTime.Now : date);

            List<_switch> upSwitches = new List<_switch>();
            List<_switch> downSwitches = new List<_switch>();

            foreach (_switch sw in repository.switches)
            {
                //linq queries inside a foreach loop is a perfomance issue but that's the easiest way
                var lastAction = (from w in sw.status
                                  where w.datetime < date
                                  let distance = w.datetime.Subtract(date.Value).Ticks
                                  orderby distance descending
                                  select w.action).AsParallel().First();


                if (lastAction == "+1")
                {
                    upSwitches.Add(sw);
                }
                else
                {
                    downSwitches.Add(sw);
                }
            }

            //more complex view model to display up and down commutators in the same page
            return View(new StatusControllerViewModel() { DownSwitches = downSwitches, UpSwitches = upSwitches });
        }

    }
}
