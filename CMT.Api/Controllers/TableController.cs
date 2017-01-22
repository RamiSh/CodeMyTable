using CMT.Repository;
using CMT.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CMT.Api.Controllers
{
    [RoutePrefix("api/v1/table")]
    public class TableController : ApiController
    {
        public TableController()
        {

        }

        [Route("")]
        [HttpGet]
        public IHttpActionResult GetTables(string connection)
        {
            ITableRepository tableRepository = new TableRepository(connection);

            return Ok(tableRepository.GetTables());
        }
    }
}
