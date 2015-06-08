using Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;


namespace GrasimAPI.Controllers
{
    /// <summary>
    /// WishList functionality
    /// </summary>
   [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class WishListController : ApiController
    {
        UserRepository userRepository;

        /// <summary>
        /// Defualt constructor
        /// </summary>
        public WishListController()
        {
            this.userRepository = new UserRepository();
        }

        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        /// <summary>
        /// Function get the details of user wish list
        /// </summary>
        /// <param name="UserId">Unique identifier of user</param>
        /// <returns>Return the wishlist of user</returns>
        public IList<TailorMaster> Get(Guid UserId)
        {
            return this.userRepository.GetWishList(UserId);
        }

        // POST api/<controller>
        public bool Post([FromBody]WishList wishList)
        {
            return this.userRepository.AddWishList(wishList.UserID,wishList.TailorID);
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}