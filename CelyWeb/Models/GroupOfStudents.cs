using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CelyWeb.Models
{
    public class GroupOfStudents : IGroupOfStudents
    {
        private ApplicationDbContext _context;

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public List<int> StudentsIds { get; set; }

        public List<IStudent> Students { get; set; }

        [Required]
        public int PaymentTypeId { get; set; }

        public IPaymentTypes PaymentType { get; set; }

        public bool IsVIP { get; set; }

        public GroupOfStudents()
        {
            _context = new ApplicationDbContext();
        }

        public bool Delete(IGroupOfStudents groupOfStudents)
        {
            throw new NotImplementedException();
        }

        public IGroupOfStudents GetGroup(int id) => _context.GroupOfStudents.Single(g => g.Id == id);

        public List<GroupOfStudents> GetGroupOfStudents() => _context.GroupOfStudents.ToList();

        public IGroupOfStudents Register(IGroupOfStudents groupOfStudents)
        {
            _context.GroupOfStudents.Add((GroupOfStudents)groupOfStudents);

            _context.SaveChanges();

            foreach (var studentId in groupOfStudents.StudentsIds)
            {
                var student = _context.Students.Single(s => s.Id == studentId);
                student.GroupOfStudentId = groupOfStudents.Id;

                new Student().Update(student);
            }

            return groupOfStudents;
        }

        public IGroupOfStudents Update(IGroupOfStudents groupOfStudents)
        {
            var groupInDb = _context.GroupOfStudents.Single(g => g.Id == groupOfStudents.Id);

            Mapper.Map((GroupOfStudents)groupOfStudents, groupInDb);

            foreach (var student in groupOfStudents.Students)
            {
                new Student().Update(student);
            }

            _context.SaveChanges();

            return groupOfStudents;
        }
    }
}