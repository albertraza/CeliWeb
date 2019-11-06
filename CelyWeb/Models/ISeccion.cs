using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CelyWeb.Models
{
     public interface ISeccion
    {
        int Id { get; set; }

        [Required]
        string Nivel { get; set; }

        [Required]
        DateTime StartDate { get; set; }

        [Required]
        DateTime DateAdded { get; set; }

        string Aula { get; set; }

        int StudentLimit { get; set; }

        [Required]
        bool IsActive { get; set; }



        ISeccion Register(ISeccion seccion);
        ISeccion Update(ISeccion seccion);
        List<ISeccion> GetSeccions();
        ISeccion GetSeccion(int id);
    }
}