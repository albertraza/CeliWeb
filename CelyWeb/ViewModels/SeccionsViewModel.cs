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

        public ISeccion Seccion { get; set; }

        public List<ISeccion> Seccions { get; set; }
    }
}