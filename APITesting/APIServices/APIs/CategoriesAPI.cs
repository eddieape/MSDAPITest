using APIServices.Models;

namespace APIServices.APIs
{
    /// <summary>
    /// To get the details of the category by using RestApiHelper
    /// </summary>
    public class CategoriesAPI
    {
        public Category GetDetailsByCategoryID(long categoryId, bool catalogue=false)
        {
            string url = $"{Constants.BASE_URL}/v1/Categories/{categoryId}/Details.json";
            Category category =  new RestApiHelper<Category>().Get(url, new { catalogue = catalogue });
            return category;
        }
    }
}
