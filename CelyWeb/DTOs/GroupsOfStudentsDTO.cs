﻿using AutoMapper;
using CelyWeb.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CelyWeb.DTOs
{
    public class GroupsOfStudentsDTO
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


        public GroupsOfStudentsDTO Register(GroupsOfStudentsDTO group)
        {
            var newGroup = new GroupOfStudents().Register(Mapper.Map<GroupsOfStudentsDTO, GroupOfStudents>(group));
            return Mapper.Map<GroupOfStudents, GroupsOfStudentsDTO>((GroupOfStudents)newGroup);
        }

        public List<GroupsOfStudentsDTO> GetGroups()
        {
            var groups = new GroupOfStudents().GetGroupOfStudents();
            var groupsToReturn = new List<GroupsOfStudentsDTO>();

            foreach (var group in groups)
            {
                groupsToReturn.Add(Mapper.Map<GroupOfStudents, GroupsOfStudentsDTO>(group));
            }

            return groupsToReturn;
        }
    }
}