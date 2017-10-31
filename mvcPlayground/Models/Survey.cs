using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace mvcPlayground.Models
{
    public class Survey
    {
        public Survey()
        {
        }

        public int Id { get; internal set; }
        public string Name { get; set; }
        public virtual ICollection<Section> Sections { get; set; }
    }

    public class SurveyDBContext : DbContext
    {
        public SurveyDBContext() : base("DefaultConnection")
        {

        }

        public DbSet<Survey> Surveys { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }



    public static class SurveyFactory
    {
        public static Survey Generate()
        {
            Survey model = new Survey()
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