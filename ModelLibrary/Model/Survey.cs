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

        public Survey(CreateSurveyDto surveyToCreate = null, AnswerSurveyDto answerToRegister = null)
        {
            if (surveyToCreate != null)
            {
                CreatorId = surveyToCreate.CreatorId;
                Title = surveyToCreate.Title;
                IsAnonymous = surveyToCreate.IsAnonymous;
                Questions = new List<Question>();

                foreach (Tuple<string, int> question in surveyToCreate.Questions)
                {
                    Question tempQuestion = new Question
                    {
                        QuestionText = question.Item1,
                        QuestionType = question.Item2,
                        Answer = null
                    };

                    Questions.Add(tempQuestion);

                }
            }

            if (answerToRegister != null)
            {
                Id = answerToRegister.SurveyId;
                Title = answerToRegister.Title;
                Questions = new List<Question>();

                foreach (Tuple<string, int, string> answer in answerToRegister.Answers)
                {
                    Answer tempAnswer = new Answer
                    {
                        AnswerText = answer.Item3
                    };

                    Question tempQuestion = new Question
                    {
                        QuestionText = answer.Item1,
                        QuestionType = answer.Item2,
                        Answer = tempAnswer
                    };

                    Questions.Add(tempQuestion);
                }
            }

            

        }


        #endregion

        #region Methods

        

        #endregion

    }
}
