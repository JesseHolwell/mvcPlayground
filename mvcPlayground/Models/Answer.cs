using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvcPlayground.Models
{
    public class Answer
    {
        public Answer()
        {

        }

        public int Id { get; internal set; }
        public int QuestionId { get; set; }
        public string Text { get; set; }
        public int Order { get; set; }
        public bool Exclusive { get; set; }

        private int getNextOrder()
        {
            throw new NotImplementedException();
        }
    }
}