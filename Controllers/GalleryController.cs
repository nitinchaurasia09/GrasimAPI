using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using Models;
using Repository;

namespace GrasimAPI.Controllers
{
    /// <summary>
    /// Gallery functionality
    /// </summary>
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class GalleryController : ApiController
    {
        TailorRepository tailorRepository;

        /// <summary>
        /// Defualt constructor
        /// </summary>
        public GalleryController()
        {
            this.tailorRepository = new TailorRepository();
        }

        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        /// <summary>
        /// Get the tailor gallery base on tailor id
        /// </summary>
        /// <param name="TailorId">Unique Identifier of Tailor</param>
        /// <returns>Return the gallery list</returns>
        public IList<Gallery> Get(Guid TailorId)
        {
            return this.tailorRepository.GetGallery(TailorId);
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