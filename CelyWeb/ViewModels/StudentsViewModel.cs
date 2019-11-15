using CelyWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CelyWeb.ViewModels
{
    public class StudentsViewModel
    {
        public Student Student { get; set; }
        public List<Student> Students { get; set; }
        public List<PaymentTypes> PaymentTypes { get; set; }
        public List<Seccion> Seccions { get; set; }
    }
}