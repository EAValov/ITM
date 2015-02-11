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
        private IDBRepository repository;
        public HomeController(IDBRepository repo)
        {
            this.repository = repo;
        }

        public ViewResult Index(string Name)
        {
            ViewBag.Switches = new SelectList(repository.switches, "Name", "Name", Name); //in constructor

            var _switch = (from r in repository.switches where r.Name == Name select r).FirstOrDefault();

            IEnumerable<status> st = (Name == null ? repository.switches.SelectMany(p => p.status) : _switch.status);

            return View(st.OrderByDescending(y => y.datetime));
        }


        public ViewResult Create()
        {
            //Viewbag collections of select options
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
                              orderby distance descending
                              select q).First();

            if (NewStatus.action != lastStatus.action && NewStatus.datetime > lastStatus.datetime)
            {
                NewStatus._switch = sw;
                repository.SaveStatus(NewStatus);

                TempData["SuccessMessage"] = string.Format("Успешно сохранено {0} для {1} в {2}",
                    (NewStatus.action == "-1" ? "Down" : "Up"),
                    NewStatus._switch.Name,
                    NewStatus.datetime);

                return RedirectToAction("Index");
            }
            else
            {
                TempData["ErrorMessage"] = string.Format("Некорректный ввод - {0} последний раз был {1} в {2}",
                    lastStatus._switch.Name,
                    (lastStatus.action == "-1" ? "Down" : "Up"),
                    lastStatus.datetime);
                return RedirectToAction("Create");
            }


        }
    }
}

