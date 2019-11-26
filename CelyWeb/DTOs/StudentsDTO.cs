
using AutoMapper;
using CelyWeb.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CelyWeb.DTOs
{
    public class StudentsDTO
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string LastName { get; set; }

        public byte[] Photo { get; set; }

        [Required]
        public DateTime DateAdded { get; set; }

        [Required]
        public DateTime PaymentDate { get; set; }

        public DateTime? LastPaymentDate { get; set; }

        [Required]
        public int SeccionId { get; set; }

        public Seccion Seccion { get; set; }

        [Required]
        public int PaymentTypeId { get; set; }

        public PaymentTypesDTO PaymentType { get; set; }

        public bool IsDelinquent { get; set; }

        public bool IsVIP { get; set; }

        public int? GroupOfStudentId { get; set; }

        public GroupsOfStudentsDTO GroupOfStudents { get; set; }

        [Required]
        public bool IsActive { get; set; }

        public DateTime? InactiveDate { get; set; }


        public List<StudentsDTO> GetStudents(string query = null)
        {
            var students = new Student().GetStudents(query);
            var studentsDTO = new List<StudentsDTO>();

            foreach (var student in students)
            {
                studentsDTO.Add(Mapper.Map<Student, StudentsDTO>(student));
            }

            return studentsDTO;
        }
    }
}