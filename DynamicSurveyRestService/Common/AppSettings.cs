using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace DynamicSurveyRestService.Common
{
    public class AppSettings
    {

        #region InstanceFields

        private readonly IConfiguration _configuration;

        #endregion

        #region Properties

        public string ConnectionString => _configuration.GetConnectionString("DefaultConnection");

        #endregion

        #region Constructor

        public AppSettings(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        #endregion

    }
}
