using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace mvcPlayground.Models
{
    public class Survey
    {
        public Survey()
        {
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Section> Sections { get; set; }
    }

    public class Section
    {
        public Section()
        {
        }

        public int Id { get; set; }
        public int SurveyId { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }

        public virtual ICollection<Question> Questions { get; set; }
    }

    public class Question
    {
        public Question()
        {
            this.Order = 0;
            //getNextOrder();
        }

        public int Id { get; set; }
        public int SectionId { get; set; }
        public string Text { get; set; }
        public int Order { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
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

    public class Answer
    {
        public Answer()
        {

        }

        public int Id { get; set; }
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