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
    public class UserController : ApiController
    {
        UserRepository userRepository;

        /// <summary>
        /// Defualt constructor
        /// </summary>
        public UserController()
        {
            this.userRepository = new UserRepository();
        }

        /// <summary>
        /// Function get the details of user
        /// </summary>
        /// <param name="UserId">Unique identifier of user</param>
        /// <returns>Return the user information</returns>
        public IList<User> Get(Guid UserId)
        {
            return this.userRepository.UserDetail(UserId);
        }

        /// <summary>
        /// Check the user exist or not
        /// </summary>
        /// <param name="UserEmail">Name of user</param>
        /// <param name="Password">Passowrd of user</param>
        /// <returns>Retun the status of user exist or not</returns>
        public User Get(string UserEmail, string Password)
        {
            return this.userRepository.UserLogin(UserEmail, Password);
        }

        /// <summary>
        /// Function modify the user function
        /// </summary>
        /// <param name="user">User object</param>
        /// <returns>Return the status of action performed</returns>
        public bool Post([FromBody]User user)
        {
            return this.userRepository.UserDetail(user);
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}