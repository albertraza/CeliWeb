using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CelyWeb.Models
{
    public class Student : IStudent
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public DateTime DateAdded { get; set; }

        [Required]
        public DateTime PaymentDate { get; set; }

        public DateTime? LastPaymentDate { get; set; }

        [Required]
        public int SeccionId { get; set; }

        public ISeccion Seccion { get; set; }

        [Required]
        public int PaymentTypeId { get; set; }

        public IPaymentTypes PaymentType { get; set; }

        public bool IsDelinquent { get; set; }

        public bool IsVIP { get; set; }

        public int? GroupOfStudentId { get; set; }

        public IGroupOfStudents GroupOfStudents { get; set; }


        public bool Delete(IStudent student)
        {
            throw new NotImplementedException();
        }

        public IStudent GetStudent(int id)
        {
            throw new NotImplementedException();
        }

        public List<IStudent> GetStudents()
        {
            throw new NotImplementedException();
        }

        public IStudent Register(IStudent student)
        {
            throw new NotImplementedException();
        }

        public IStudent Update(IStudent student)
        {
            throw new NotImplementedException();
        }
    }
}