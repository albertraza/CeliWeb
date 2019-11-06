using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelyWeb.Models
{
    public interface IStudent
    {
        int Id { get; set; }

        [Required]
        string Name { get; set; }

        [Required]
        string LastName { get; set; }

        [Required]
        DateTime DateAdded { get; set; }

        [Required]
        DateTime PaymentDate { get; set; }

        DateTime? LastPaymentDate { get; set; }

        [Required]
        int SeccionId { get; set; }

        ISeccion Seccion { get; set; }

        [Required]
        int PaymentTypeId { get; set; }

        IPaymentTypes PaymentType { get; set; }

        bool IsDelinquent { get; set; }

        bool IsVIP { get; set; }

        int? GroupOfStudentId { get; set; }

        IGroupOfStudents GroupOfStudents { get; set; }



        IStudent Register(IStudent student);
        IStudent Update(IStudent student);
        bool Delete(IStudent student);
        List<IStudent> GetStudents();
        IStudent GetStudent(int id);
    }
}
