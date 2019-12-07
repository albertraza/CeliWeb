using AutoMapper;
using CelyWeb.DTOs;
using CelyWeb.Models;
using CelyWeb.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CelyWeb.Controllers.Api
{
    public class GroupsController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Save(GroupsOfStudentsDTO groupDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            if (!groupDTO.IsRegistered)
            {
                foreach (var studentId in groupDTO.StudentsIds)
                {
                    var student = new Student().GetStudent(studentId);

                    if (student.GroupOfStudentId != 0)
                        return BadRequest(string.Format("El Estudiante ({0} {1}) ya esta en una Familia.", student.Name, student.LastName));
                }

                if (!new PaymentTypes().GetPaymentType(groupDTO.PaymentTypeId).IsForGroups)
                    return BadRequest("El Metodo de pago no es para Familias");

                var group = new GroupOfStudents().Register(Mapper.Map<GroupsOfStudentsDTO, GroupOfStudents>(groupDTO));

                Mapper.Map((GroupOfStudents)group, groupDTO);
                return Created(new Uri(Request.RequestUri + "/" + group.Id), groupDTO);
            }
            else
            {
                new GroupOfStudents().Update(Mapper.Map<GroupsOfStudentsDTO, GroupOfStudents>(groupDTO));
                return Ok();
            }
        }

        public IHttpActionResult GetAllGroups()
        {
            return Ok(new GroupsOfStudentsDTO().GetGroups());
        }
    }
}
