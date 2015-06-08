using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using Repository;
using Models;

namespace GrasimAPI.Controllers
{
    /// <summary>
    /// Tailor functionality
    /// </summary>
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class TailorController : ApiController
    {
        TailorRepository tailorRepository;

        /// <summary>
        /// Defualt constructor
        /// </summary>
        public TailorController()
        {
            this.tailorRepository = new TailorRepository();
        }


        // GET api/<controller>
        public IEnumerable<string> Get(decimal Latitude, decimal Longitude)
        {
            return new string[] { "value1", "value2" };
        }

        /// <summary>
        /// Get the tailor information 
        /// </summary>
        /// <param name="TailorId">Unique identifier of tailor</param>
        /// <returns>Return the tailor detail</returns>
        public TailorMaster Get(Guid TailorId)
        {
            TailorMaster resultList = new TailorMaster();
            resultList = this.tailorRepository.GetTailor(TailorId);
            resultList.ReviewList = this.tailorRepository.GetReview(resultList.GUID);
            resultList.GalleryList = this.tailorRepository.GetGallery(resultList.GUID);
            return resultList;
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
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