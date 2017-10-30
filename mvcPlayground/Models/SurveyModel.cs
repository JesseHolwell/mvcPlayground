using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace mvcPlayground.Models
{
    public class SurveyModel
    {
        public int Id { get; internal set; }
        public string Name { get; set; }
        public virtual ICollection<SectionModel> Sections { get; set; }

    }

    public class SectionModel
    {
        public int Id { get; internal set; }
        public int SurveyId { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }

        public virtual ICollection<QuestionModel> Questions { get; set; }
    }

    public class QuestionModel
    {
        public int Id { get; internal set; }
        public int SectionId { get; set; }
        public QuestionModel()
        {
            this.Order = 0;
            //getNextOrder();
        }

        public string Question { get; set; }
        public int Order { get; set; }
        public virtual ICollection<AnswerModel> Answers { get; set; }
        public QuestionType Type { get; set; }

        private int getNextOrder()
        {
            throw new NotImplementedException();
        }
    }

    public class AnswerModel
    {
        public int Id { get; internal set; }
        public int QuestionId { get; set; }
        public AnswerModel()
        {
            this.Order = 0;
            //getNextOrder();
        }

        public string Answer { get; set; }
        public int Order { get; set; }
        public bool Exclusive { get; set; }

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




    public class SurveyDBContext : DbContext
    {
        public SurveyDBContext() : base("DefaultConnection")
        {

        }

        public DbSet<SurveyModel> Surveys { get; set; }
        public DbSet<SectionModel> Sections { get; set; }
        public DbSet<QuestionModel> Questions { get; set; }
        public DbSet<AnswerModel> Answers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }



    public static class SurveyFactory
    {
        public static SurveyModel Generate()
        {
            SurveyModel model = new SurveyModel()
            {
                Id = 1,
                Name = "Test Survey",
                Sections = new List<SectionModel>()
                    {
                        new SectionModel()
                        {
                            Id = 1,
                            Name = "Text",
                            Questions = new List<QuestionModel>()
                            {
                                new QuestionModel()
                                {
                                    Id = 1,
                                    Question = "Test question number 1",
                                    Type = QuestionType.Single,
                                    Answers = new List<AnswerModel>
                                    {
                                        new AnswerModel()
                                        {
                                            Id = 1,
                                            Answer = "Test answer",
                                            Exclusive = false,
                                        }
                                    }
                                }
                            }
                        }
                    }
            };

            return model;
        }
    }
}