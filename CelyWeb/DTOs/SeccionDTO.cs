using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CelyWeb.DTOs
{
    public class SeccionDTO
    {
        public int Id { get; set; }

        [Required]
        public string Nivel { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime DateAdded { get; set; }

        public string Aula { get; set; }

        public int StudentLimit { get; set; }

        [Required]
        public bool IsActive { get; set; }
    }
}