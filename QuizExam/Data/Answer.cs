//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QuizExam.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Answer
    {
        public int answerID { get; set; }
        public Nullable<int> optionID { get; set; }
        public Nullable<int> quizID { get; set; }
    
        public virtual ItemOption ItemOption { get; set; }
        public virtual Quiz Quiz { get; set; }
    }
}
