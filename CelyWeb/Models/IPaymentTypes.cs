using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CelyWeb.Models
{
    interface IPaymentTypes
    {
        int Id { get; set; }
        string Type { get; set; }
        double Amount { get; set; }
        int DaysToPay { get; set; }
    }
}