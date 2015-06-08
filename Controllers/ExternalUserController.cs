using Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;


namespace GrasimAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ExternalUserController : ApiController
    {
        UserRepository userRepository;

        /// <summary>
        /// Defualt constructor
        /// </summary>
        public ExternalUserController()
        {
            this.userRepository = new UserRepository();
        }


        /// <summary>
        /// Function modify the user function
        /// </summary>
        /// <param name="user">User object</param>
        /// <returns>Return the status of action performed</returns>
        [HttpPost]
        public bool Post([FromBody]ExternalUser user)
        {
            return this.userRepository.AddExternalUser(user.ID, user.FirstName, user.LastName, user.Email, user.AccType);
        }
    }
}