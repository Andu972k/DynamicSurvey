using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLibrary.DTO
{
    public class AnswerSurveyDto
    {

        #region properties

        public int SurveyId { get; set; }

        public int UserId { get; set; }

        public string Title { get; set; }

        public List<Tuple<string, int, string>> Answers { get; set; }

        #endregion

    }
}
