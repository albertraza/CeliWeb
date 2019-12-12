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
            return View(new PaymentTypesViewModel { PaymentTypes = new PaymentTypes().GetPaymentTypes() });
        }

        public ActionResult New()
        {
            return View("PaymentTypesForm", new PaymentTypesViewModel());
        }

        public ActionResult Save(PaymentTypesViewModel viewModel)
        {
            if (!ModelState.IsValid)
                throw new NullReferenceException("One or multiple inputs are invalid");

            viewModel.PaymentType = (PaymentTypes)new PaymentTypes().Register(viewModel.PaymentType);

            return View("Index", new PaymentTypesViewModel { PaymentTypes = new PaymentTypes().GetPaymentTypes() });
        }

        public ActionResult Details(int id)
        {
            return View(new PaymentTypesViewModel { PaymentType = (PaymentTypes)new PaymentTypes().GetPaymentType(id) });
        }
    }
}