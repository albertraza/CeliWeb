using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CelyWeb.Models
{
    public class PaymentTypes : IPaymentTypes
    {
        private ApplicationDbContext _context;

        public int Id { get; set; }

        [Required]
        public DateTime DateAdded { get; set;}

        [Required]
        [Display(Name = "Nombre del tipo de pago")]
        public string Type {get; set; }

        [Required]
        [Display(Name ="Cantidad a Pagar")]
        public double Amount {get; set; }

        [Required]
        [Display(Name ="Cantidad de Dias para pagar")]
        public int DaysToPay {get; set; }

        public PaymentTypes()
        {
            _context = new ApplicationDbContext();
        }

        public IPaymentTypes GetPaymentType(int id)
        {
            var paymentType = _context.PaymentTypes.Single(p => p.Id == id);
            return paymentType;

        }

        public IPaymentTypes Register(IPaymentTypes paymentType)
        {
            paymentType.DateAdded = DateTime.Today;

            _context.PaymentTypes.Add((PaymentTypes)paymentType);
            _context.SaveChanges();

            return paymentType;
        }

        public List<IPaymentTypes> GetPaymentTypes()
        {
            var paymentTypes = _context.PaymentTypes.ToList();
            var list = new List<IPaymentTypes>();

            foreach (var paymentType in paymentTypes)
            {
                list.Add(paymentType);
            }

            return list;
        }
    }
}