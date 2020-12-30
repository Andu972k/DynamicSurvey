using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DynamicSurveyWebApp.Model
{
    public class Survey
    {

        #region Properties

        public int Id { get; set; }

        public int CreatorId { get; set; }

        public string Title { get; set; }

        public bool IsAnonymous { get; set; }

        public List<Question> Questions { get; set; }

        #endregion

    }
}
