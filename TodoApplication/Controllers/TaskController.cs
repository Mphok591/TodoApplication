using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TodoApplication.Models;

namespace TodoApplication.Controllers
{
    public class TaskController : Controller
    {
        private TDatabaseEntities db = new TDatabaseEntities();
        // GET: Task
        [HttpGet]
        public ActionResult Index()
        {
            var _taskList = db.ListItems.ToList();
            return View(_taskList);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(ListItem listItem)
        {
            db.ListItems.Add(listItem);
            db.SaveChanges();
            ViewBag.Message = "New";
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var storedData = db.ListItems.Where(x => x.Id == id).FirstOrDefault();
            return View(storedData);
        }
        [HttpPost]
        public ActionResult Edit(ListItem listItem)
        {
            var storedData = db.ListItems.Where(x => x.Id == listItem.Id).FirstOrDefault();
            if (storedData == null)
            {
                storedData.Name = listItem.Name;
                storedData.Description = listItem.Description;
                db.SaveChanges();
                ViewBag.Message = "Done";
               
            }
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            var storedData = db.ListItems.Where(x => x.Id == id).FirstOrDefault();
            return View(storedData);
        }
    }
}