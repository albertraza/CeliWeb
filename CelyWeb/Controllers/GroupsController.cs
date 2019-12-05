using CelyWeb.Models;
using CelyWeb.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CelyWeb.Controllers
{
    public class GroupsController : Controller
    {
        // GET: Groups
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult New()
        {
            return View("GroupsForm");
        }

        public ActionResult Details(int id)
        {
            return View();
        }
    }
}