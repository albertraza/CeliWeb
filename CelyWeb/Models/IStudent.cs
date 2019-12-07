using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CelyWeb.Models
{
    public interface IStudent
    {
        int Id { get; set; }

        [Required]
        string Name { get; set; }

        [Required]
        string LastName { get; set; }

        byte[] Photo { get; set; }

        [Required]
        DateTime DateAdded { get; set; }

        [Required]
        DateTime PaymentDate { get; set; }

        DateTime? LastPaymentDate { get; set; }

        [Required]
        int SeccionId { get; set; }

        [Required]
        int PaymentTypeId { get; set; }

        bool IsDelinquent { get; set; }

        bool IsVIP { get; set; }

        int GroupOfStudentId { get; set; }

        [Required]
        bool IsActive { get; set; }

        DateTime? InactiveDate { get; set; }

        IStudent Register(IStudent student, HttpPostedFileBase Photo);
        IStudent Update(IStudent student, HttpPostedFileBase Photo);
        bool Delete(IStudent student);
        IStudent GetStudent(int id);
    }
}
