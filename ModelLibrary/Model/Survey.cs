using System;
using System.Collections.Generic;
using System.Text;
using ModelLibrary.DTO;

namespace ModelLibrary.Model
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


        #region Constructor

        public Survey(CreateSurveyDto surveyToCreate)
        {
            CreatorId = surveyToCreate.CreatorId;
            Title = surveyToCreate.Title;
            IsAnonymous = surveyToCreate.IsAnonymous;
            Questions = new List<Question>();

            foreach ((string QuestionText, int QuestionType) question in surveyToCreate.Questions)
            {
                Question tempQuestion = new Question
                {
                    QuestionText = question.QuestionText,
                    QuestionType = question.QuestionType,
                    Answer = null
                };

                Questions.Add(tempQuestion);

            }

        }


        #endregion

        #region Methods

        

        #endregion

    }
}
