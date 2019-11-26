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
        public IHttpActionResult GetStudents(string query = null)
        {
            return Ok(new StudentsDTO().GetStudents(query));
        }
    }
}
