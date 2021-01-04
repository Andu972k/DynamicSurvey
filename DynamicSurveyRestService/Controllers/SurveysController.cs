using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DynamicSurveyRestService.DataAccess;
using Microsoft.AspNetCore.Mvc;
using ModelLibrary.DTO;
using ModelLibrary.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DynamicSurveyRestService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveysController : ControllerBase
    {

        #region InstanceFields

        private readonly SurveysRepository _repository;

        #endregion

        #region Constructor

        public SurveysController(SurveysRepository repository)
        {
            _repository = repository;
        }

        #endregion


        // GET: api/<SurveysController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<SurveysController>/5
        [HttpGet("{id}")]
        public async Task<GetOneSurveyResponseDto> GetOneSurveyAsync(int id)
        {
            return await _repository.GetOneAsync(id);
        }

        // POST api/<SurveysController>
        [HttpPost]
        public async Task<CreateSurveyResponseDto> CreateSurveyAsync([FromBody] CreateSurveyDto surveyInformation)
        {
            Survey tempSurvey = new Survey(surveyInformation);

            CreateSurveyResponseDto repsonse = await _repository.CreateSurveyAsync(tempSurvey);

            return repsonse;

        }

        [HttpPost]
        [Route("Answer")]
        public async Task<AnswerSurveyResponseDto> Answer([FromBody] AnswerSurveyDto answer)
        {
            Survey tempSurvey = new Survey( null, answer);

            User tempUser = new User
            {
                Id = answer.UserId
            };

            AnswerSurveyResponseDto response = await _repository.AnswerSurveyAsync(tempSurvey, tempUser);

            return response;
        }

        // PUT api/<SurveysController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SurveysController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
