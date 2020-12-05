using System;
using System.Collections.Generic;
using System.Text;
using ModelLibrary.Model;

namespace ModelLibrary.DTO
{
    public class QuestionDto
    {

        #region Properties

        public string QuestionText { get; set; }

        public int QuestionType { get; set; }

        public List<AnswerDto> Answers { get; set; }

        #endregion


        #region Constructor



        #endregion

    }
}
