using Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Script;

namespace GrasimAPI.Controllers
{
    /// <summary>
    /// Search functionality
    /// </summary>
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class SearchController : ApiController
    {

        TailorRepository tailorRepository;

        /// <summary>
        /// Defualt constructor
        /// </summary>
        public SearchController()
        {
            this.tailorRepository = new TailorRepository();
        }

        /// <summary>
        /// Get the tailor informaton based on search criteria
        /// </summary>
        /// <param name="TailorName">Name of the tailor</param>
        /// <param name="Latitude">Latitude of the location</param>
        /// <param name="Longitude">Longitude of the location</param>
        /// <returns>Return tailor list base on search criteria</returns>
        [HttpGet]
        public IList<TailorMaster> SearchTailor(string TailorName, decimal? Latitude, decimal? Longitude)
        {
            return this.tailorRepository.SearchTailor(TailorName, Latitude, Longitude);
        }

        /// <summary>
        /// Get the tailor informaton based on feature and category
        /// </summary>
        /// <param name="Feature">Category of the tailor</param>
        /// <param name="Category">Category of the tailor</param>
        /// <param name="Latitude">Latitude of the location</param>
        /// <param name="Longitude">Longitude of the location</param>
        /// <returns>Return tailor list base on search criteria</returns>
        [HttpGet]
        public IList<TailorMaster> SearchTailor(Guid Feature, Guid Category, decimal? Latitude, decimal? Longitude)
        {
            return this.tailorRepository.SearchTailor(Feature, Category, Latitude, Longitude);
        }

        [HttpGet]
        public IList<TailorMaster> SearchTailor(Guid Feature, decimal? Latitude, decimal? Longitude, int trend)
        {
            return this.tailorRepository.SearchTailor(Feature, Latitude, Longitude, trend);
        }

        [HttpGet]
        public IList<TailorMaster> SearchTailor(decimal Latitude, decimal Longitude)
        {
            return this.tailorRepository.SearchTailor(Latitude, Longitude);
        }

        [HttpGet]
        public IList<TailorMaster> SearchTailor(decimal Latitude, decimal Longitude, int nearby)
        {
            return this.tailorRepository.SearchTailor(Latitude, Longitude, nearby);
        }

        [HttpGet]
        public TailorMaster SearchTailor(Guid TailorId, decimal? Latitude, decimal? Longitude)
        {
            TailorMaster resultList = new TailorMaster();
            resultList = this.tailorRepository.SearchTailor(TailorId, Latitude, Longitude);
            resultList.ReviewList = this.tailorRepository.GetReview(resultList.GUID);
            resultList.GalleryList = this.tailorRepository.GetThreeGallery(resultList.GUID);
            return resultList;
        }

    }
}
