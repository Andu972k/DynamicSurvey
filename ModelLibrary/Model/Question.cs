using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLibrary.Model
{
    public class Question
    {

        #region Properties

        public string QuestionText { get; set; }

        public int QuestionType { get; set; }

        public Answer Answer { get; set; }

        #endregion


        #region Constructor

        public Question()
        {
            
        }

        #endregion

        #region Methods



        #endregion


    }
}
