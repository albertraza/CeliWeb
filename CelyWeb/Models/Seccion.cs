using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CelyWeb.Models
{
    public class Seccion : ISeccion
    {

        private ApplicationDbContext _context;

        public int Id { get; set; }

        [Required]
        public string Nivel { get; set; }

        [Required]
        [Display(Name ="Fecha de Inicio")]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime DateAdded { get; set; }

        public string Aula {get; set;  }

        [Display(Name ="Limite Estudiantil")]
        public int StudentLimit { get; set; }

        [Required]
        [Display(Name ="¿Esta Activo?")]
        public bool IsActive {get; set;  }


        public Seccion()
        {
            _context = new ApplicationDbContext();
        }


        public ISeccion GetSeccion(int id)
        {
            return _context.Seccions.Single(s => s.Id == id);
        }

        public List<Seccion> GetSeccions()
        { 
            var seccions = _context.Seccions.ToList();
            return seccions;
        }

        public ISeccion Register(ISeccion seccion)
        {
            seccion.DateAdded = DateTime.Today;

            _context.Seccions.Add((Seccion)seccion);
            _context.SaveChanges();

            return seccion;
        }

        public ISeccion Update(ISeccion seccion)
        {
            var seccionInDB = _context.Seccions.Single(s => s.Id == seccion.Id);

            seccionInDB.IsActive = seccion.IsActive;
            seccionInDB.Aula = seccion.Aula;
            seccionInDB.Nivel = seccion.Nivel;
            seccionInDB.StudentLimit = seccion.StudentLimit;

            _context.SaveChanges();

            return seccion;
        }
    }
}