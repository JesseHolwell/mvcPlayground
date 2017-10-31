using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvcPlayground.Models
{
    public class Question
    {
        public Question()
        {
            this.Order = 0;
            //getNextOrder();
        }

        public int Id { get; internal set; }
        public int SectionId { get; set; }
        public string Question { get; set; }
        public int Order { get; set; }
        public virtual ICollection<AnswerModel> Answers { get; set; }
        public QuestionType Type { get; set; }

        private int getNextOrder()
        {
            throw new NotImplementedException();
        }
    }

    public enum QuestionType
    {
        Single,
        Matrix
    }
}