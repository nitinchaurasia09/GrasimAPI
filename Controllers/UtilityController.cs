using Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace GrasimAPI.Controllers
{
    /// <summary>
    /// Achive the common functionality
    /// </summary>
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UtilityController : ApiController
    {
        UtilityRepository utility;

        /// <summary>
        /// Defualt constructor
        /// </summary>
        public UtilityController()
        {
            this.utility = new UtilityRepository();
        }

        /// <summary>
        /// Get the feature list 
        /// </summary>
        /// <returns>Return feature list</returns>
        [HttpGet]
        public IList<Feature> GetFeatures()
        {
            return utility.GetFeatures();
        }

        [HttpGet]
        public IList<TailorMaster> GetLocationsByName()
        {
            return utility.GetLocations();
        }
        /// <summary>
        /// Get the category list 
        /// </summary>
        /// <returns>Return category list</returns>
        [HttpGet]
        public IList<Category> Categories()
        {
            return utility.GetCategories();
        }

        [HttpGet]
        public IList<Category> CategoriesByFeatureId(Guid featureId)
        {
            return utility.GetCategoriesByFeatureId(featureId);
        }


        /// <summary>
        /// Get the feature and category list combined
        /// </summary>
        /// <returns>Return feature and category list</returns>
        [HttpGet]
        public IList<Feature> FeartureCategoriesList()
        {
            IList<Feature> resultList = new List<Feature>();
            resultList = GetFeatures();
            foreach (Feature feature in resultList)
            {
                feature.CategoryList = CategoriesByFeatureId(feature.GUID);
            }
            return resultList;
        }

        /// <summary>
        /// Get the deals of tailor
        /// </summary>
        /// <returns>Return deals list</returns>
        [HttpGet]
        public IList<Deals> DealsByTailorId(Guid TailorId)
        {
            return utility.GetDeals(TailorId);
        }

        /// <summary>
        /// Get the deals of tailor
        /// </summary>
        /// <returns>Return deals list</returns>
        [HttpGet]
        public IList<Deals> AllDeals()
        {
            return utility.GetAllDeals();
        }

        /// <summary>
        /// Get the pages
        /// </summary>
        /// <returns>Return pages</returns>
        [HttpGet]
        public IList<static_pages> GetPageByPageId(int guid)
        {
            return utility.GetPageDescription(guid);
        }
    }
}
