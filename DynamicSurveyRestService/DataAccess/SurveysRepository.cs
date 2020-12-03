using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DynamicSurveyRestService.Common;

namespace DynamicSurveyRestService.DataAccess
{
    public class SurveysRepository
    {


        #region InstanceFields

        private readonly DBContext _dbContext;

        #endregion

        #region SQL-Statements



        #endregion

        #region Constructor

        public SurveysRepository(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        #endregion


        #region Methods


        //public async Task<> CreateSurvey()
        //{

        //}

        #endregion


    }
}
