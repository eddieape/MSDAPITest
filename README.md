## MSDAPITest
---
This repo is an API testing task for the Product Test Analyst role.

### Prerequisites

* Visual Studio 2019 or higher for backend development: [Visual Studio](https://visualstudio.microsoft.com/)
* Git for Windows: [Git](https://git-scm.com/download/win)

### Getting Started

* Clone this project using your preferred git client.
* Open the solution named "APITesting.sln" via Visual Studio 2019
* Compile the whole solution via Visual Studio 2019
* Run tests by launching the project named "APITests"

### Description

The solution consists of two projects, APITests and APIServices. APITests is responsible for API unit testing based on the MSTest framework, while APIServices is a class library that provides related API functions and reporting generation methods. The test report locates in the TestResults directory, using the browser to open the file "index.html" to view the test results.  

Three Nuget packages are imported into the solution： 

1. Newtonsoft.Json
2. RestSharp
3. ExtentReports

### Test Framework

Based on the requirements of API automation testing, I chose the MSTest framework. Using assert classes and attributes of framework members, I create three test cases to help me check whether to meet the acceptance criterion.  

### Test Design

---
* Test Data  
categoryId = 6327  
baseUrl = "https://api.tmsandbox.co.nz"  
endpoint = "/v1/Categories/{categoryId}/Details.json?catalogue=false"  

* Test helper classes  
RestApiHelp - Encapsulates the Http Request operation by using RestSharp  
Reporter - To manage reporting by using Extent Report  
CategoriesAPI - To get the details of the category by using RestApiHelper


* Test methods
1. VerifyNameField_ShouldReturnCorrespondedCategoryName_WhenValidRequest
     ```
    // Arrange
      1. Ready Test Data
      2. Create the categories API;

    // Act
      3. Call the categories API to send the request to get the details of the category

    // Assert
      4. Check if the name of the category is "Carbon credits"
     ```

2. VerifyCanRelistField_ShouldReturnTure_WhenValidRequest

     ```
    // Arrange
      1. Ready Test Data
      2. Create the categories API;

    // Act
      3. Call the categories API to send the request to get the details of the category

    // Assert
      4. Check if the value of the CanRelist is true 
     ```

3. VerifySpecifiedPromotionElement_ShouldReturnRelatedDescription_WhenValidRequest

     ```
    // Arrange
      1. Ready Test Data
      2. Create the categories API;

    // Act
      3. Call the categories API to send the request to get the details of the category
      4. Find the promotion element named "Gallery"

    // Assert
      5. Check if the description of promotion contains "Good position in category"
     ```

---  

### Suggestions about the AC
I think the HTTP status code should be verified. For example, creating a resource should return 201 CREATED, disallowed requests should return 403 FORBIDDEN, etc.  
