using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CelyWeb.Models.CustomValidations
{
    public class VIPRequired : ValidationAttribute
    {
        private ApplicationDbContext _context;

        public VIPRequired()
        {
            _context = new ApplicationDbContext();
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var student = (Student)validationContext.ObjectInstance;

            var paymentType = _context.PaymentTypes.Single(p => p.Id == student.PaymentTypeId);

            if (paymentType.IsVIP)
            {
                if (student.IsVIP)
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult("El Estudiante debe ser VIP para elegir este metodo de pago.");
                }
            }
            else
            {
                if (student.IsVIP)
                {
                    return new ValidationResult("El Metodo de pago debe ser VIP");
                }
                else
                {
                    return ValidationResult.Success;
                }
            }
           
        }
    }
}