using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using DynamicSurveyRestService.Common;
using ModelLibrary.DTO;
using ModelLibrary.Model;
using Newtonsoft.Json;

namespace DynamicSurveyRestService.DataAccess
{
    public class SurveysRepository
    {


        #region InstanceFields

        private readonly DBContext _dbContext;

        #endregion

        #region SQL-Statements

        private const string CreateSurveyStatement = "Insert into Surveys (CreatorID, Title, IsAnonymous, Questions) Values (@CreatorID, @Title, @IsAnonymous, JSON_QUERY(@Questions))";

        private const string AnswerSurveyStatement = "Insert into Answers (SurveyID, UserID, Answers) Values (@SurveyID, @UserID, @Answers)";

        #endregion

        #region Constructor

        public SurveysRepository(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        #endregion


        #region Methods


        public async Task<CreateSurveyResponseDto> CreateSurveyAsync(Survey survey)
        {

            CreateSurveyResponseDto repsonse = new CreateSurveyResponseDto();

            using (SqlConnection connection = await _dbContext.OpenConnectionAsync())
            {
                using (SqlCommand command = new SqlCommand(CreateSurveyStatement, connection))
                {
                    command.Parameters.AddWithValue("@CreatorID", survey.CreatorId);
                    command.Parameters.AddWithValue("@Title", survey.Title);
                    command.Parameters.AddWithValue("@IsAnonymous", survey.IsAnonymous);
                    command.Parameters.AddWithValue("@Questions", JsonConvert.SerializeObject(survey.Questions));

                    

                    int rowsAffected = await command.ExecuteNonQueryAsync();

                    if (rowsAffected == 1)
                    {
                        repsonse.ResponseMessage = $"Survey was successfully created with the following Title: {survey.Title}. The first question of the survey is: {survey.Questions[0].QuestionText}";
                    }



                }
            }

            return repsonse;

        }


        public async Task<AnswerSurveyResponseDto> AnswerSurveyAsync(Survey survey, User user)
        {
            AnswerSurveyResponseDto response = new AnswerSurveyResponseDto();

            using (SqlConnection connection = await _dbContext.OpenConnectionAsync())
            {
                using (SqlCommand command = new SqlCommand(AnswerSurveyStatement, connection))
                {

                    command.Parameters.AddWithValue("@SurveyID", survey.Id);
                    command.Parameters.AddWithValue("@UserID", user.Id);
                    command.Parameters.AddWithValue("@Answers", JsonConvert.SerializeObject(survey.Questions));

                    int rowsAffected = await command.ExecuteNonQueryAsync();

                    if (rowsAffected == 1)
                    {
                        response.ResponseMessage = $"Your answer has been registered for the survey titled: {survey.Title}";
                    }

                }
            }

            return response;
        }

        #endregion


    }
}
