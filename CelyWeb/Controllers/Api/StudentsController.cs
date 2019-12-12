using CelyWeb.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CelyWeb.Controllers.Api
{
    public class StudentsController : ApiController
    {
        public IHttpActionResult GetStudents(string query = null) => Ok(new StudentsDTO().GetStudents(query));

        public IHttpActionResult GetStudent(int id)
        {
            var student = new StudentsDTO().GetStudent(id);
            if (student == null)
                NotFound();
            return Ok(student);
        }

        [HttpPut]
        public IHttpActionResult Update(StudentsDTO student)
        {
            if (student == null)
                NotFound();

            return Ok(new StudentsDTO().Update(student));
        }
    }
}
