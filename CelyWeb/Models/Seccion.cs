using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CelyWeb.Models
{
    public class Seccion : ISeccion
    {
        public int Id { get; set; }

        [Required]
        public string Nivel { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime DateAdded { get; set; }

        public string Aula {get; set;  }

        public int StudentLimit { get; set; }

        [Required]
        public bool IsActive {get; set;  }


        public ISeccion GetSeccion(int id)
        {
            throw new NotImplementedException();
        }

        public List<ISeccion> GetSeccions()
        {
            throw new NotImplementedException();
        }

        public ISeccion Register(ISeccion seccion)
        {
            throw new NotImplementedException();
        }

        public ISeccion Update(ISeccion seccion)
        {
            throw new NotImplementedException();
        }
    }
}