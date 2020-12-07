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

        #endregion

        #region Constructor

        public SurveysRepository(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        #endregion


        #region Methods


        public async Task<CreateSurveyRepsonseDto> CreateSurvey(Survey survey)
        {

            CreateSurveyRepsonseDto repsonse = new CreateSurveyRepsonseDto();

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
                        repsonse.ResponseMessage = "Survey was successfully created";
                    }



                }
            }

            return repsonse;

        }

        #endregion


    }
}
