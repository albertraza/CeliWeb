﻿using System;
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

        [Required]
        public bool IsVIP { get; set; }

        [Required]
        public bool IsForGroups { get; set; }

        public PaymentTypes()
        {
            _context = new ApplicationDbContext();
        }

        public IPaymentTypes GetPaymentType(int id) => _context.PaymentTypes.Single(p => p.Id == id);

        public IPaymentTypes Register(IPaymentTypes paymentType)
        {

            paymentType.Type = paymentType.Type + " " + DateTime.Today.ToString("MMM/yyyy");

            if (paymentType.IsVIP)
                paymentType.Type = paymentType.Type + " -VIP";

            if (paymentType.IsForGroups)
                paymentType.Type = paymentType.Type + " -Familiar";

            paymentType.DateAdded = DateTime.Today;

            _context.PaymentTypes.Add((PaymentTypes)paymentType);
            _context.SaveChanges();

            return paymentType;
        }

        public List<PaymentTypes> GetPaymentTypes(string query = null)
        {
            if (query != null)
                return _context.PaymentTypes.Where(p => p.Type.Contains(query)).ToList();

            return _context.PaymentTypes.ToList();
        }
    }
}