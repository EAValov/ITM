using ITMApp.DBContext;
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
        //IEnumerable<_switch> Switches = new List<_switch>()
        //{
        //    new _switch() 
        //    { 
        //        Name = "Commutator 1",
        //        switchID = 1,
        //        status = new Collection<status>() 
        //        {
        //            new status() { switchID = 1, datetime = DateTime.Now, action = "+1"},
        //            new status() { switchID = 1, datetime = DateTime.Now.AddSeconds(10), action = "-1"},
        //            new status() { switchID = 1, datetime = DateTime.Now.AddSeconds(20), action = "+1"},
        //            new status() { switchID = 1, datetime = DateTime.Now.AddSeconds(30), action = "-1"},
        //            new status() { switchID = 1, datetime = DateTime.Now.AddSeconds(40), action = "+1"},
        //        }  
        //    },
        //    new _switch() 
        //    { 
        //        Name = "Comswitcher 2",
        //        switchID = 2,
        //        status = new Collection<status>() 
        //        {
        //            new status() { switchID = 2, datetime = DateTime.Now, action = "+1"},
        //            new status() { switchID = 2, datetime = DateTime.Now.AddSeconds(20), action = "-1"},
        //            new status() { switchID = 2, datetime = DateTime.Now.AddSeconds(50), action = "+1"},
        //            new status() { switchID = 2, datetime = DateTime.Now.AddSeconds(100), action = "-1"},
        //            new status() { switchID = 2, datetime = DateTime.Now.AddSeconds(150), action = "+1"},
        //        }  
        //    },
        //    new _switch() 
        //    { 
        //        Name = "Flicker 3",
        //        switchID = 3,
        //        status = new Collection<status>() 
        //        {
        //            new status() { switchID = 3, datetime = DateTime.Now, action = "+1"},
        //            new status() { switchID = 3, datetime = DateTime.Now.AddSeconds(1), action = "-1"},
        //            new status() { switchID = 3, datetime = DateTime.Now.AddSeconds(2), action = "+1"},
        //            new status() { switchID = 3, datetime = DateTime.Now.AddSeconds(3), action = "-1"},
        //            new status() { switchID = 3, datetime = DateTime.Now.AddSeconds(4), action = "+1"},
        //            new status() { switchID = 3, datetime = DateTime.Now.AddSeconds(5), action = "-1"},
        //            new status() { switchID = 3, datetime = DateTime.Now.AddSeconds(6), action = "+1"},
        //            new status() { switchID = 3, datetime = DateTime.Now.AddSeconds(7), action = "-1"},
        //            new status() { switchID = 3, datetime = DateTime.Now.AddSeconds(8), action = "+1"},
        //            new status() { switchID = 3, datetime = DateTime.Now.AddSeconds(9), action = "-1"},

        //        }  
        //    }
        //};

        private IDBRepository repository = new EFDBRepository();

        //public HomeController(IDBRepository repo) 
        //{ 
        //    this.repository = repo;
        //    ViewBag.Switches = new SelectList(repository.switches.Select(r => r.Name)); //in constructor
        //}

        public ViewResult Index(string Name)
        {
            ViewBag.Switches = new SelectList(repository.switches, "Name", "Name", Name); //in constructor

            var _switch = (from r in repository.switches where r.Name == Name select r).FirstOrDefault();

            IEnumerable<status> st = (Name == null ? repository.switches.SelectMany(p => p.status) : _switch.status);

            return View(st.OrderByDescending(y => y.datetime));
        }


        public ViewResult Create()
        {
            ViewBag.Switches = new SelectList(repository.switches, "switchID", "Name"); //in constructor
            ViewBag.PossibleActions = new SelectList(
                new[]
            { 
                new SelectListItem() { Text = "Up", Value = "+1" },
                new SelectListItem() { Text = "Down", Value = "-1" }
            }, "Value", "Text");

            return View("Create", new status());
        }

        [HttpPost]
        public ActionResult Create(status NewStatus)
        {
            _switch sw = (from r in repository.switches where r.switchID == NewStatus.switchID select r).FirstOrDefault();

            //find out closest date
            var lastStatus = (from q in sw.status
                              let distance = q.datetime.Subtract(NewStatus.datetime).Ticks
                              orderby distance ascending
                              select q).First();

            if (NewStatus.action != lastStatus.action)
            {
                NewStatus._switch = sw;
                repository.SaveStatus(NewStatus);
                //tempdata message
                return RedirectToAction("Index");
            }
            else
            {
                //tempdata ololo
                return RedirectToAction("Create");
            }

           
        }
    }
}

