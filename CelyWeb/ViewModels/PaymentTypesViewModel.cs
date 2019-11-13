using CelyWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CelyWeb.ViewModels
{
    public class PaymentTypesViewModel
    {
        public PaymentTypes PaymentType { get; set; }
        public List<PaymentTypes> PaymentTypes { get; set; }
    }
}