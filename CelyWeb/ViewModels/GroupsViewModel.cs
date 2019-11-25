using CelyWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CelyWeb.ViewModels
{
    public class GroupsViewModel
    {
        public GroupOfStudents GroupOfStudents { get; set; }
        public List<PaymentTypes> PaymentTypes { get; set; }
    }
}