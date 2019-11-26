using CelyWeb.Models.CustomValidations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
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

        public byte[] Photo { get; set; }

        [Required]
        public DateTime DateAdded { get; set; }

        [Required]
        public DateTime PaymentDate { get; set; }

        public DateTime? LastPaymentDate { get; set; }

        [Required]
        [Display(Name ="Seccion")]
        public int SeccionId { get; set; }

        public Seccion Seccion { get; set; }

        [Required]
        [VIPRequired]
        [Display(Name ="Tipo de Pago")]
        public int PaymentTypeId { get; set; }

        public PaymentTypes PaymentType { get; set; }

        public bool IsDelinquent { get; set; }

        public bool IsVIP { get; set; }

        public int? GroupOfStudentId { get; set; }

        public GroupOfStudents GroupOfStudents { get; set; }

        [Required]
        public bool IsActive { get; set; }

        public DateTime? InactiveDate { get; set; }


        public Student()
        {
            _context = new ApplicationDbContext();
        }

        public bool Delete(IStudent student)
        {
            var studentInDb = _context.Students.Single(s => s.Id == student.Id);
            studentInDb.IsActive = false;
            studentInDb.InactiveDate = DateTime.Today;

            _context.SaveChanges();
            return true;
        }

        public IStudent GetStudent(int id) => _context.Students.Include(s => s.PaymentType).Include(s => s.Seccion).Single(s => s.Id == id);

        public List<Student> GetStudents(string query = null)
        {
            if (query != null)
                return _context.Students.Include(s => s.PaymentType).Include(s => s.Seccion).Where(s => s.Name.Contains(query) || s.LastName.Contains(query)).ToList();

          return _context.Students.Include(s => s.PaymentType).Include(s => s.Seccion).ToList();
        }

        public IStudent Register(IStudent student, HttpPostedFileBase Photo)
        {
            if(Photo != null)
            {
                student.Photo = new byte[Photo.ContentLength];
                Photo.InputStream.Read(student.Photo, 0, Photo.ContentLength);
            }

            student.DateAdded = DateTime.Today;
            student.PaymentDate = DateTime.Today.AddDays(_context.PaymentTypes.Single(p => p.Id == student.PaymentTypeId).DaysToPay);
            student.IsActive = true;

            _context.Students.Add((Student)student);

            _context.SaveChanges();

            return student;
        }

        public IStudent Update(IStudent student, HttpPostedFileBase Photo = null)
        {
            var studentInDb = _context.Students.Single(s => s.Id == student.Id);

            studentInDb.Name = student.Name;
            studentInDb.LastName = student.LastName;
            studentInDb.IsVIP = student.IsVIP;
            studentInDb.PaymentTypeId = student.PaymentTypeId;
            studentInDb.SeccionId = student.SeccionId;
            studentInDb.GroupOfStudentId = student.GroupOfStudentId;

            if(Photo != null)
            {
                studentInDb.Photo = new byte[Photo.ContentLength];
                Photo.InputStream.Read(studentInDb.Photo, 0, Photo.ContentLength);
            }

            _context.SaveChanges();

            // retrieving all new info, updated.
            studentInDb = _context.Students.Include(s => s.Seccion).Include(s => s.PaymentType).Single(s => s.Id == student.Id);

            return studentInDb;
        }
    }
}