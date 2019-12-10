using AutoMapper;
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
        #region contructor
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public List<int> StudentsIds { get; set; }

        public List<StudentsDTO> Students { get; set; }

        [Required]
        public int PaymentTypeId { get; set; }

        public PaymentTypesDTO PaymentType { get; set; }

        public bool IsVIP { get; set; }

        public bool IsRegistered
        { get
            {
                if (this != null)
                    if (Id != 0)
                        return true;
                return false;
         } }
        #endregion constructor

        #region Register method
        public GroupsOfStudentsDTO Register(GroupsOfStudentsDTO group)
        {
            var newGroup = new GroupOfStudents().Register(Mapper.Map<GroupsOfStudentsDTO, GroupOfStudents>(group));
            return Mapper.Map<GroupOfStudents, GroupsOfStudentsDTO>((GroupOfStudents)newGroup);
        }
        #endregion Register method

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

        public GroupsOfStudentsDTO GetGroup(int id) => Mapper.Map<GroupOfStudents, GroupsOfStudentsDTO>((GroupOfStudents)new GroupOfStudents().GetGroup(id));

        public GroupsOfStudentsDTO Update(GroupsOfStudentsDTO groupOfStudents)
        {
            var group = Mapper.Map<GroupsOfStudentsDTO, GroupOfStudents>(groupOfStudents);
            return Mapper.Map<GroupOfStudents, GroupsOfStudentsDTO>((GroupOfStudents)new GroupOfStudents().Update(group));
        }

        public bool Delete(GroupsOfStudentsDTO groupOfStudents)
        {
            return new GroupOfStudents().Delete(Mapper.Map<GroupsOfStudentsDTO, GroupOfStudents>(groupOfStudents));
        }
    }
}