using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLibrary.DTO
{
    public class CreateSurveyDto
    {

        #region Properties

        public int CreatorId { get; set; }

        public string Title { get; set; }

        public bool IsAnonymous { get; set; }

        public List<Tuple<string, int>> Questions { get; set; }

        #endregion

        #region Constructor



        #endregion



    }
}
