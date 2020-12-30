using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DynamicSurveyWebApp.Model
{
    public class Question
    {
        #region Properties

        public string QuestionText { get; set; }

        public int QuestionType { get; set; }

        public Answer Answer { get; set; }

        #endregion
    }
}
