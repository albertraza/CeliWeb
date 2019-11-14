using CelyWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CelyWeb.ViewModels
{
    public class SeccionsViewModel
    {
        public string Title
        {
            get
            {
                if (Seccion.Id != 0)
                {
                    return "Modify Seccion";
                }
                else
                {
                    return "New Seccion";
                }
            }
        }

        public Seccion Seccion { get; set; }

        public List<Seccion> Seccions { get; set; }
    }
}