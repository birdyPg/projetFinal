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
    
    public partial class ItemOption
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ItemOption()
        {
            this.Answers = new HashSet<Answer>();
        }
    
        public int optionID { get; set; }
        public string text { get; set; }
        public bool isRight { get; set; }
        public Nullable<int> questionID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Answer> Answers { get; set; }
        public virtual Question Question { get; set; }
    }
}
