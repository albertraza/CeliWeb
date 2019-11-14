using CelyWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CelyWeb.ViewModels
{
    public class PaymentTypesViewModel
    {
        public IPaymentTypes PaymentType { get; set; }
        public List<IPaymentTypes> PaymentTypes { get; set; }
    }
}