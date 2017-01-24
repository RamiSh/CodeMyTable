using CMT.Repository;
using CMT.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

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
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult GetTables(string connection)
        {
            ITableRepository tableRepository = new TableRepository(connection);

            return Ok(tableRepository.GetTables());
        }

        [Route("{tableName:string}/columns/{owner:string}")]
        [HttpGet]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult GetColumns(string connection)
        {
            ITableRepository tableRepository = new TableRepository(connection);

            return Ok(tableRepository.GetTables());
        }
    }
}
