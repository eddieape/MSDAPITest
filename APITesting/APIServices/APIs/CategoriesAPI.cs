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
        public Category GetDetailsByCategoryID(long categoryId, bool ca=false)
        {
            var restApiHelper = new RestAPIHelper<Category>();
            string url = $"https://api.tmsandbox.co.nz/v1/Categories/{categoryId}/Details.json";

            Category category =  new RestAPIHelper<Category>().Get(url, new { catalogue = ca });
            return category;
        }
    }
}
