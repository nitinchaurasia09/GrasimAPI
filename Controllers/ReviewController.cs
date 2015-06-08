using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using Models;
using Repository;

namespace GrasimAPI.Controllers
{
    /// <summary>
    /// Review functionality
    /// </summary>
   [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ReviewController : ApiController
    {
        TailorRepository tailorRepository;

        /// <summary>
        /// Defualt constructor
        /// </summary>
        public ReviewController()
        {
            this.tailorRepository = new TailorRepository();
        }

        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]Review review)
        {
            //this.tailorRepository.AddReview(review.TailorId,review.UserId,review.Name,review.Email,review.Description,review.ReviewTitle,review.Timeline,review.Rating);
            this.tailorRepository.AddReview(review.TailorId, review.UserId, review.Comment, review.ReviewTitle, review.Rating);
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