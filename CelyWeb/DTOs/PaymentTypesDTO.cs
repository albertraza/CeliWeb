using AutoMapper;
using CelyWeb.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CelyWeb.DTOs
{
    public class PaymentTypesDTO
    {
        public int Id { get; set; }

        [Required]
        public DateTime DateAdded { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public double Amount { get; set; }

        [Required]
        public int DaysToPay { get; set; }

        [Required]
        public bool IsVIP { get; set; }

        [Required]
        public bool IsForGroups { get; set; }

        public List<PaymentTypesDTO> GetPaymentTypes(string query = null)
        {
            var paymentTypes = new PaymentTypes().GetPaymentTypes(query);
            var paymentTypesDTO = new List<PaymentTypesDTO>();

            foreach (var paymentType in paymentTypes)
            {
                paymentTypesDTO.Add(Mapper.Map<PaymentTypes, PaymentTypesDTO>(paymentType));
            }

            return paymentTypesDTO;
        }

    }
}