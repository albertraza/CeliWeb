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

            if (viewModel.Seccion.Id == 0)
            {
                new Seccion().Register(viewModel.Seccion);

                return View("Index", new SeccionsViewModel { Seccions = new Seccion().GetSeccions() });
            }
            else
            {
                viewModel.Seccion = (Seccion) new Seccion().Update(viewModel.Seccion);
                return View("Details", viewModel);
            }
        }

        public ActionResult New()
        {
            return View("SeccionForm", new SeccionsViewModel { Seccion = new Seccion()});
        }

        public ActionResult Details(int id)
        {
            var viewModel = new SeccionsViewModel { Seccion = (Seccion) new Seccion().GetSeccion(id) };

            return View(viewModel);
        }

        public ActionResult Modify(int id)
        {
            return View("SeccionForm", new SeccionsViewModel { Seccion = (Seccion) new Seccion().GetSeccion(id) });
        }
    }
}