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
            return View(new StudentsViewModel { PaymentTypes = new PaymentTypes().GetPaymentTypes(), Seccions = new Seccion().GetSeccions(), Student = new Student() });
        }

        [HttpPost]
        public ActionResult Save(StudentsViewModel viewModel, HttpPostedFileBase Photo)
        {
            if (!ModelState.IsValid)
            {
                viewModel.PaymentTypes = new PaymentTypes().GetPaymentTypes();
                viewModel.Seccions = new Seccion().GetSeccions();

                return View("Register", viewModel);
            }

            if (viewModel.Student.Id == 0)
            {
                viewModel.Student = (Student)new Student().Register(viewModel.Student, Photo);

                return View("Index", new StudentsViewModel { Students = new Student().GetStudents() });
            }
            else
            {
                return View("Details", new StudentsViewModel { Student = (Student)new Student().Update(viewModel.Student, Photo) });
            }
        }

        public ActionResult Details(int id)
        {
            return View(new StudentsViewModel { Student = (Student)new Student().GetStudent(id) });
        }

        public ActionResult Modify(int id)
        {
            return View("Register", new StudentsViewModel { PaymentTypes = new PaymentTypes().GetPaymentTypes(), Seccions = new Seccion().GetSeccions(), Student = (Student)new Student().GetStudent(id) });
        }
    }
}