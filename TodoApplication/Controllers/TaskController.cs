﻿using System;
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
        public ActionResult Index()
        {
            var _taskList = db.ListItems.ToList();
            return View(_taskList);
        }
    }
}