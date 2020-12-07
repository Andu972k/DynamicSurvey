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
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SurveysController>
        [HttpPost]
        public async Task<CreateSurveyRepsonseDto> Post([FromBody] CreateSurveyDto surveyInformation)
        {
            Survey tempSurvey = new Survey(surveyInformation);

            CreateSurveyRepsonseDto repsonse = await _repository.CreateSurvey(tempSurvey);

            return repsonse;

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
