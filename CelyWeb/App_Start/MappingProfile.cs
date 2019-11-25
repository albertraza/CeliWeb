using AutoMapper;
using CelyWeb.DTOs;
using CelyWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CelyWeb.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<GroupOfStudents, GroupsOfStudentsDTO>();
            Mapper.CreateMap<GroupsOfStudentsDTO, GroupOfStudents>();
        }
    }
}