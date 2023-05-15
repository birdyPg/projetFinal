using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuizExam.Data
{
    using System;
    using System.Collections.Generic;

    public partial class Question
    {
        public int selectedOptionID { get; set; } = 0;

        public int answeredOptionId( int quizID) {

            if (this.Quizs.Where(x => x.quizID == quizID).FirstOrDefault().
                    Answers.Count == 0)
            {
                throw new Exception("the quiz was not finished yet.");
            }

            return this.Quizs.Where(x => x.quizID == quizID).FirstOrDefault().
                    Answers.Where(x => x.ItemOption.questionID == this.questionID).FirstOrDefault()
                    .optionID.Value;
        }
    }
}