using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CelyWeb.Models
{
    public class PaymentTypes : IPaymentTypes
    {
        public int Id { get; set; }

        [Required]
        public DateTime DateAdded { get; set;}

        [Required]
        public string Type {get; set; }

        [Required]
        public double Amount {get; set; }

        [Required]
        public int DaysToPay {get; set; }


        public IPaymentTypes GetPaymentType(int id)
        {
            throw new NotImplementedException();
        }

        public IPaymentTypes Register(IPaymentTypes paymentType)
        {
            throw new NotImplementedException();
        }
    }
}