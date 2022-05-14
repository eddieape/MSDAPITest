using APIServices.APIs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace APITests
{
    [TestClass]
    public class CategoriesAPITests
    {
        [TestMethod]
        public void VerifyNameField_ShouldReturnCorrespondedCategoryName_WhenValidRequest()
        {
            // Arrange
            long categroyId = 6327;
            var categoriesAPI = new CategoriesAPI();
            // Act
            var category = categoriesAPI.GetDetailsByCategoryID(categroyId);

            // Assert
            Assert.IsNotNull(category);
            Assert.AreEqual("Carbon credits", category.Name);
        }

        public void VerifyCanRelistField_ShouldReturnTure_WhenValidRequest()
        {
            // Arrange

            // Act

            // Assert

        }

        public void VerifySpecifiedPromotionElement_ShouldReturnRelatedDescription_WhenValidRequest()
        {
            // Arrange

            // Act

            // Assert

        }
    }
}
