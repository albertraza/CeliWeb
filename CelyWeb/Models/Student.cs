using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CelyWeb.Models
{
    public class Student : IStudent
    {
        private ApplicationDbContext _context;

        public int Id { get; set; }

        [Required]
        [Display(Name ="Nombre")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Apellidos")]
        public string LastName { get; set; }

        [Required]
        public DateTime DateAdded { get; set; }

        [Required]
        public DateTime PaymentDate { get; set; }

        public DateTime? LastPaymentDate { get; set; }

        [Required]
        [Display(Name ="Seccion")]
        public int SeccionId { get; set; }

        public ISeccion Seccion { get; set; }

        [Required]
        [Display(Name ="Tipo de Pago")]
        public int PaymentTypeId { get; set; }

        public IPaymentTypes PaymentType { get; set; }

        public bool IsDelinquent { get; set; }

        public bool IsVIP { get; set; }

        public int? GroupOfStudentId { get; set; }

        public IGroupOfStudents GroupOfStudents { get; set; }

        public Student()
        {
            _context = new ApplicationDbContext();
        }

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
            student.DateAdded = DateTime.Today;
            student.PaymentDate = DateTime.Today.AddDays(_context.PaymentTypes.Single(p => p.Id == student.PaymentTypeId).DaysToPay);

            _context.Students.Add((Student)student);

            return student;
        }

        public IStudent Update(IStudent student)
        {
            throw new NotImplementedException();
        }
    }
}