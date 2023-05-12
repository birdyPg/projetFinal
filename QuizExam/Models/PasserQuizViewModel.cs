using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuizExam.Models
{
    public class PasserQuizViewModel
    {
        public int QuizId { get; set; }
        public List<PasserQuestionViewModel> Questions { get; set; }
    }
    public class PasserQuestionViewModel
    {
        public int QuestionId { get; set; }
        public string Text { get; set; }
        public string Category { get; set; }
        public List<PasserOptionViewModel> Options { get; set; }
    }
    public class PasserOptionViewModel
    {
        public int OptionId { get; set; }
        public string Text { get; set; }
    }
}