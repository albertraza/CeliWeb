using CelyWeb.Models;
using CelyWeb.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CelyWeb.Controllers
{
    public class SeccionsController : Controller
    {
        // GET: Seccions
        public ActionResult Index()
        {
            var viewModel = new SeccionsViewModel { Seccions = new Seccion().GetSeccions() };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Save(SeccionsViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View("SeccionForm", viewModel);

            viewModel.Seccion.DateAdded = DateTime.Today;
            new Seccion().Register(viewModel.Seccion);

            return View("Index");
        }

        public ActionResult New()
        {
            return View("SeccionForm");
        }
    }
}