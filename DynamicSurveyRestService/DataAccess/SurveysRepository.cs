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

        private const string GetOneStatement = "Select * From Surveys Where ID = @ID";

        private const string CreateSurveyStatement = "Insert into Surveys (CreatorID, Title, IsAnonymous, Questions) Values (@CreatorID, @Title, @IsAnonymous, JSON_QUERY(@Questions))";

        private const string AnswerSurveyStatement = "Insert into Answers (SurveyID, UserID, Answers) Values (@SurveyID, @UserID, JSON_QUERY(@Answers))";

        #endregion

        #region Constructor

        public SurveysRepository(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        #endregion


        #region Methods

        public async Task<GetOneSurveyResponseDto> GetOneAsync(int id)
        {
            GetOneSurveyResponseDto response = new GetOneSurveyResponseDto();

            using (SqlConnection connection = await _dbContext.OpenConnectionAsync())
            {
                using (SqlCommand command = new SqlCommand(GetOneStatement, connection))
                {
                    command.Parameters.AddWithValue("@ID", id);

                    SqlDataReader reader = await command.ExecuteReaderAsync();

                    while (reader.Read())
                    {
                        response.Survey = ReadSurvey(reader);
                    }
                }
            }

            return response;
        }

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


        #region HelpMethods

        private Survey ReadSurvey(SqlDataReader reader)
        {
            Survey tempSurvey = new Survey
            {
                Id = reader.GetInt32(0),
                CreatorId = reader.GetInt32(1),
                Title = reader.GetString(2),
                IsAnonymous = reader.GetBoolean(3),
                Questions = JsonConvert.DeserializeObject<List<Question>>(reader.GetString(4))
            };

            return tempSurvey;
        }

        #endregion

    }
}
