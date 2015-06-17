using Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace GrasimAPI.Controllers
{
    /// <summary>
    /// User functionality
    /// </summary>
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class QueryController : ApiController
    {
        QueryRepository queryRepository;

        public QueryController()
        {
            this.queryRepository = new QueryRepository();
        }


        /// <summary>
        /// Function add the query function
        /// </summary>
        /// <param name="user">User object</param>
        /// <returns>Return the status of action performed</returns>
        public bool Post([FromBody]Query query)
        {
            return this.queryRepository.AddQuery(query);
        }
    }
}