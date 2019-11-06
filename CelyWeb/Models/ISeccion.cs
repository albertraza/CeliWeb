using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CelyWeb.Models
{
     interface ISeccion
    {
        int Id { get; set; }
        string Nivel { get; set; }
        string Aula { get; set; }
        int StudentLimit { get; set; }
    }
}