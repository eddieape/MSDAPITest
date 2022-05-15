﻿using APIServices;
using APIServices.APIs;
using AventStack.ExtentReports;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace APITests
{
    [TestClass]
    public class CategoriesAPITests
    {
        public TestContext TestContext { get; set; }


        [ClassInitialize]
        public static void Setup(TestContext textContext)
        {
            var dir = textContext.TestRunDirectory;
            Reporter.SetupExtentReport("API Automation Test", "API Automation Test Report", dir);
        }

        [TestInitialize]
        public void SetupTest()
        {
            Reporter.CreateTest(TestContext.TestName);
        }

        [TestCleanup]
        public void CleanupTest()
        {
            var testStatus = TestContext.CurrentTestOutcome;
            Status logStatus;
            switch (testStatus)
            {
                case UnitTestOutcome.Failed:
                    logStatus = Status.Fail;
                    Reporter.TestStatus(logStatus.ToString());
                    break;
                case UnitTestOutcome.Inconclusive:
                    break;
                case UnitTestOutcome.Passed:
                    logStatus = Status.Pass;
                    Reporter.TestStatus(logStatus.ToString());
                    break;
                case UnitTestOutcome.InProgress:
                    break;
                case UnitTestOutcome.Error:
                    break;
                case UnitTestOutcome.Timeout:
                    break;
                case UnitTestOutcome.Aborted:
                    break;
                case UnitTestOutcome.Unknown:
                    break;
                case UnitTestOutcome.NotRunnable:
                    break;
                default:
                    break;
            }
        }

        [ClassCleanup]
        public static void Cleanup()
        {
            Reporter.FlushReport();
        }

        [MyTestMethod]
        public void VerifyNameField_ShouldReturnCorrespondedCategoryName_WhenValidRequest()
        {
            // Arrange
            long categoryId = 6327;
            Reporter.LogToReport(Status.Info, "Test data for categoryId is: " + categoryId);
            var categoriesAPI = new CategoriesAPI();

            // Act
            var category = categoriesAPI.GetDetailsByCategoryID(categoryId);

            // Assert
            Assert.IsNotNull(category);
            Reporter.LogToReport(Status.Pass, "Get the details of category");

            Assert.AreEqual("Carbon credits", category.Name);
            Reporter.LogToReport(Status.Pass, "The name of category is " + category.Name);

        }

        [MyTestMethod]
        public void VerifyCanRelistField_ShouldReturnTure_WhenValidRequest()
        {
            // Arrange
            long categoryId = 6327;
            Reporter.LogToReport(Status.Info, "Test data for categoryId is: " + categoryId);
            var categoriesAPI = new CategoriesAPI();

            // Act
            var category = categoriesAPI.GetDetailsByCategoryID(categoryId);

            // Assert
            Assert.IsNotNull(category);
            Reporter.LogToReport(Status.Pass, "Get the details of category");
            Assert.IsTrue(category.CanRelist);
            Reporter.LogToReport(Status.Pass, "The value of CanRelist is true");

        }

        [MyTestMethod]
        public void VerifySpecifiedPromotionElement_ShouldReturnRelatedDescription_WhenValidRequest()
        {
            // Arrange
            long categoryId = 6327;
            Reporter.LogToReport(Status.Info, "Test data for categoryId is: " + categoryId);
            string categoryName = "Gallery";
            Reporter.LogToReport(Status.Info, "Test data for the name of promotion is: " + categoryName);
            string description = "Good position in category";
            Reporter.LogToReport(Status.Info, "Test data for the description of promotion contains: " + description);
            var categoriesAPI = new CategoriesAPI();

            // Act
            var category = categoriesAPI.GetDetailsByCategoryID(categoryId);
            var promotion = category.Promotions.Find(item => item.Name == categoryName);

            // Assert
            Assert.IsNotNull(category);
            Reporter.LogToReport(Status.Pass, "Get the details of category");
            StringAssert.Contains(promotion.Description, description);
            Reporter.LogToReport(Status.Pass, "The description of promotion is " + promotion.Description);

        }
    }


    public class MyTestMethodAttribute : TestMethodAttribute
    {
        public override TestResult[] Execute(ITestMethod testMethod)
        {
            TestResult[] results = base.Execute(testMethod);

            foreach (TestResult result in results)
            {
                if (result.Outcome == UnitTestOutcome.Failed)
                {
                    string message = result.TestFailureException.Message;
                    Reporter.LogToReport(Status.Fail, message);
                }
            }

            return results;
        }
    }
}
