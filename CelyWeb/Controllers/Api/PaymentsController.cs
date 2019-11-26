using CelyWeb.DTOs;
using CelyWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CelyWeb.Controllers.Api
{
    public class PaymentsController : ApiController
    {
        public IHttpActionResult GetPaymentTypes(string query = null)
        {
            return Ok(new PaymentTypesDTO().GetPaymentTypes(query));
        }
    }
}
