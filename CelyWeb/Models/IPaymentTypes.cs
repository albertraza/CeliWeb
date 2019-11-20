using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CelyWeb.Models
{
    public interface IPaymentTypes
    {
        int Id { get; set; }

        [Required]
        DateTime DateAdded { get; set; }

        [Required]
        string Type { get; set; }

        [Required]
        double Amount { get; set; }

        [Required]
        int DaysToPay { get; set; }

        [Required]
        bool IsVIP { get; set; }

        [Required]
        bool IsForGroups { get; set; }

        IPaymentTypes Register(IPaymentTypes paymentType);
        IPaymentTypes GetPaymentType(int id);
    }
}