using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CelyWeb.Models
{
    public class GroupOfStudents : IGroupOfStudents
    {
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


        public bool Delete(IGroupOfStudents groupOfStudents)
        {
            throw new NotImplementedException();
        }

        public IGroupOfStudents GetGroup(int id)
        {
            throw new NotImplementedException();
        }

        public List<IGroupOfStudents> GetGroupOfStudents()
        {
            throw new NotImplementedException();
        }

        public IGroupOfStudents Register(IGroupOfStudents groupOfStudents)
        {
            throw new NotImplementedException();
        }

        public IGroupOfStudents Update(IGroupOfStudents groupOfStudents)
        {
            throw new NotImplementedException();
        }
    }
}