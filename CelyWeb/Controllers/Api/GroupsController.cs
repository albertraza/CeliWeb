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
        public IHttpActionResult Save(GroupsViewModel viewModel)
        {
            //if (!ModelState.IsValid)
            //    return 

            if (viewModel.GroupOfStudents.Id == 0)
            {
                new GroupOfStudents().Register(viewModel.GroupOfStudents);
                return Ok();
            }
            else
            {
                new GroupOfStudents().Update(viewModel.GroupOfStudents);
                return Ok();
            }
        }

        public IHttpActionResult GetAllGroups()
        {
            return Ok(new Student().GetStudents());
        }
    }
}
