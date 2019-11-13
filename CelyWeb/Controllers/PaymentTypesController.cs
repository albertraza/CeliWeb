using CelyWeb.Models;
using CelyWeb.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CelyWeb.Controllers
{
    public class PaymentTypesController : Controller
    {
        // GET: PaymentTypes
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult New()
        {
            return View("PaymentTypesForm", new PaymentTypesViewModel());
        }

        public ActionResult Save(PaymentTypesViewModel viewModel)
        {
            if (!ModelState.IsValid)
                throw new NullReferenceException("One or multiple inputs are invalid");

            viewModel.PaymentTypes = (PaymentTypes)new PaymentTypes().Register(viewModel.PaymentTypes);

            return View("PaymentTypesForm", viewModel);
        }
    }
}