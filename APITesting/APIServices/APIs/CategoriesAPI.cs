using APIServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIServices.APIs
{
    public class CategoriesAPI
    {
        public string _baseUrl = "https://api.tmsandbox.co.nz";
        public Category GetDetailsByCategoryID(long categoryId, bool ca=false)
        {
            var restApiHelper = new RestApiHelper<Category>();
            string url = $"{_baseUrl}/v1/Categories/{categoryId}/Details.json";

            Category category =  new RestApiHelper<Category>().Get(url, new { catalogue = ca });
            return category;
        }
    }
}
