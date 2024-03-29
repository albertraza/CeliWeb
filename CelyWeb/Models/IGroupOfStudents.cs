﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CelyWeb.Models
{
    public interface IGroupOfStudents
    {
        int Id { get; set; }

        [Required]
        string Name { get; set; }

        [Required]
        List<int> StudentsIds { get; set; }

        [Required]
        int PaymentTypeId { get; set; }

        bool IsVIP { get; set; }



        IGroupOfStudents Register(IGroupOfStudents groupOfStudents);
        bool Delete(IGroupOfStudents groupOfStudents);
        IGroupOfStudents GetGroup(int id);
    }
}