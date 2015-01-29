using ITMApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ITMApp.Controllers
{
    public class HomeController : Controller
    {
        IEnumerable<Switch> Switches = new List<Switch>()
        {
            new Switch() 
            { 
                Name = "Commutator 1",
                switchID = 1,
                Statuses = new Collection<Status>() 
                {
                    new Status() { switchID = 1, datetime = DateTime.Now, action = "+1"},
                    new Status() { switchID = 1, datetime = DateTime.Now.AddSeconds(10), action = "-1"},
                    new Status() { switchID = 1, datetime = DateTime.Now.AddSeconds(20), action = "+1"},
                    new Status() { switchID = 1, datetime = DateTime.Now.AddSeconds(30), action = "-1"},
                    new Status() { switchID = 1, datetime = DateTime.Now.AddSeconds(40), action = "+1"},
                }  
            },
            new Switch() 
            { 
                Name = "Comswitcher 2",
                switchID = 2,
                Statuses = new Collection<Status>() 
                {
                    new Status() { switchID = 2, datetime = DateTime.Now, action = "+1"},
                    new Status() { switchID = 2, datetime = DateTime.Now.AddSeconds(20), action = "-1"},
                    new Status() { switchID = 2, datetime = DateTime.Now.AddSeconds(50), action = "+1"},
                    new Status() { switchID = 2, datetime = DateTime.Now.AddSeconds(100), action = "-1"},
                    new Status() { switchID = 2, datetime = DateTime.Now.AddSeconds(150), action = "+1"},
                }  
            },
            new Switch() 
            { 
                Name = "Flicker 3",
                switchID = 3,
                Statuses = new Collection<Status>() 
                {
                    new Status() { switchID = 3, datetime = DateTime.Now, action = "+1"},
                    new Status() { switchID = 3, datetime = DateTime.Now.AddSeconds(1), action = "-1"},
                    new Status() { switchID = 3, datetime = DateTime.Now.AddSeconds(2), action = "+1"},
                    new Status() { switchID = 3, datetime = DateTime.Now.AddSeconds(3), action = "-1"},
                    new Status() { switchID = 3, datetime = DateTime.Now.AddSeconds(4), action = "+1"},
                    new Status() { switchID = 3, datetime = DateTime.Now.AddSeconds(5), action = "-1"},
                    new Status() { switchID = 3, datetime = DateTime.Now.AddSeconds(6), action = "+1"},
                    new Status() { switchID = 3, datetime = DateTime.Now.AddSeconds(7), action = "-1"},
                    new Status() { switchID = 3, datetime = DateTime.Now.AddSeconds(8), action = "+1"},
                    new Status() { switchID = 3, datetime = DateTime.Now.AddSeconds(9), action = "-1"},

                }  
            }
        };

        public ViewResult Index(string Name)
        {
            ViewBag.Switches = new SelectList(Switches.Select(r => r.Name), Name); //in constructor

            var Switch = (from r in Switches where r.Name == Name select r).FirstOrDefault();

            IEnumerable<Status> st = (Name == null ? Switches.SelectMany(p=>p.Statuses) : Switch.Statuses);

            return View(st.OrderByDescending(y => y.datetime));
        }


        public ViewResult Create()
        {
            ViewBag.Commutators = new SelectList(Switches, "switchID", "Name");

            ViewBag.Actions = new List<SelectListItem>() 
            { 
                new SelectListItem() { Text = "Up", Value = "+1" },
                new SelectListItem() { Text = "Down", Value = "-1" }
            };

            return View("Create", new Status());
        }

        [HttpPost]
        public ActionResult Create(Status NewStatus)
        {
            Switch sw = (from r in Switches where r.switchID == NewStatus.switchID select r).FirstOrDefault();

            //find out closest date
            var closestStatus = (from q in sw.Statuses
                                 let distance = q.datetime.Subtract(NewStatus.datetime).Ticks
                                 orderby distance
                                 select q).First();

            ViewBag.PossibleAction = closestStatus.action == "+1" ? "Down" : "Up";

            sw.Statuses.Add(NewStatus);
            return RedirectToAction("Index");
        }
    }
}

