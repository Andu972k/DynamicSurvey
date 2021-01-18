using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DynamicSurveyRestService.Common;
using DynamicSurveyRestService.DataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelLibrary.DTO;
using ModelLibrary.Model;

namespace DynamicSurveyTests
{
    [TestClass]
    public class SurveyRepositoryTest
    {


        [TestMethod]
        public void CreateSurvey_()
        {
            //Arrange
            DBContext context = new DBContext(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=DynamicSurvey;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            SurveysRepository repository = new SurveysRepository(context);

            List<Tuple<string, int>> testList = new List<Tuple<string, int>>();

            testList.Add(new Tuple<string, int>("UnitTestQuestion", 1));

            testList.Add(new Tuple<string, int>("UnitTestQuestion2", 1));

            Survey testSurvey = new Survey(new CreateSurveyDto{ CreatorId = 1, IsAnonymous = true, Questions = testList, Title = "UnitTestTitle"});

            //Act
            Task<CreateSurveyResponseDto> responseTask = repository.CreateSurveyAsync(testSurvey);

            CreateSurveyResponseDto response = responseTask.Result;


            //Assert
            Assert.AreEqual(testSurvey.Title, response.ResponseMessage.Split(':')[1].Split('.')[0].Substring(1));
            Assert.AreEqual(testSurvey.Questions[0].QuestionText, response.ResponseMessage.Split(':')[2].Substring(1));


        }


    }
}
