using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelyWeb.Models
{
    interface IStudent
    {
        int Id { get; set; }
        string Name { get; set; }
        string LastName { get; set; }
        DateTime DateAdded { get; set; }
        DateTime PaymentDate { get; set; }
        ISeccion Seccion { get; set; }
        IPaymentTypes PaymentType { get; set; }
    }
}
