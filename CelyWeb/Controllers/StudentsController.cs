using CelyWeb.Models;
using CelyWeb.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CelyWeb.Controllers
{
    public class StudentsController : Controller
    {
        // GET: Students
        public ActionResult Index()
        {
            return View(new StudentsViewModel { Students = new Student().GetStudents() });
        }

        public ActionResult Register()
        {
            return View(new StudentsViewModel { PaymentTypes = new PaymentTypes().GetPaymentTypes(), Seccions = new Seccion().GetSeccions() });
        }

        [HttpPost]
        public ActionResult Save(StudentsViewModel viewModel)
        {
            if (!ModelState.IsValid)
                throw new Exception("Uno o mas inputs no estan llenos");

            viewModel.Student = (Student)new Student().Register(viewModel.Student);

            return View("Index", new StudentsViewModel { Students = new Student().GetStudents() });
        }

        public ActionResult Details(int id)
        {
            return View(new StudentsViewModel { Student = (Student)new Student().GetStudent(id) });
        }
    }
}