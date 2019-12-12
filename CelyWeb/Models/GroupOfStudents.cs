using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
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

        public List<Student> Students { get; set; }

        [Required]
        public int PaymentTypeId { get; set; }

        public PaymentTypes PaymentType { get; set; }

        public bool IsVIP { get; set; }

        public GroupOfStudents()
        {
            _context = new ApplicationDbContext();
        }

        public bool Delete(IGroupOfStudents groupOfStudents)
        {
            _context.GroupOfStudents.Remove((GroupOfStudents)groupOfStudents);
            return true;
        }

        public IGroupOfStudents GetGroup(int id)
        {
            var group = _context.GroupOfStudents.Include(g => g.PaymentType).SingleOrDefault(g => g.Id == id);

            if (group != null)
                group.Students = new Student().GetStudents(group.Id.ToString());

            return group;
        }
        public List<GroupOfStudents> GetGroupOfStudents() => _context.GroupOfStudents.ToList();

        public IGroupOfStudents Register(IGroupOfStudents groupOfStudents)
        {
            _context.GroupOfStudents.Add((GroupOfStudents)groupOfStudents);

            _context.SaveChanges();

            foreach (var studentId in groupOfStudents.StudentsIds)
            {
                var student = _context.Students.Single(s => s.Id == studentId);
                student.GroupOfStudentId = groupOfStudents.Id;
                student.PaymentTypeId = groupOfStudents.PaymentTypeId;
                student.IsVIP = groupOfStudents.IsVIP;
                student.PaymentDate = DateTime.Today.AddDays(new PaymentTypes().GetPaymentType(groupOfStudents.PaymentTypeId).DaysToPay);

                new Student().Update(student);
            }

            return groupOfStudents;
        }

        public IGroupOfStudents Update(GroupOfStudents groupOfStudents)
        {
            var groupInDb = _context.GroupOfStudents.Single(g => g.Id == groupOfStudents.Id);

            groupInDb.Name = groupOfStudents.Name;
            groupInDb.PaymentTypeId = groupOfStudents.PaymentTypeId;
            groupInDb.StudentsIds = groupOfStudents.StudentsIds;
            groupInDb.IsVIP = groupOfStudents.IsVIP;

            foreach (var studentId in groupOfStudents.StudentsIds)
            {
                var student = new Student().GetStudent(studentId);
                student.GroupOfStudentId = groupInDb.Id;
                student.PaymentTypeId = groupOfStudents.PaymentTypeId;
                student.IsVIP = groupOfStudents.IsVIP;
                new Student().Update(student);
            }

            _context.SaveChanges();

            return groupOfStudents;
        }
    }
}