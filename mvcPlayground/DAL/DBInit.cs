using mvcPlayground.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvcPlayground.DAL
{
    public class DBInit : System.Data.Entity.DropCreateDatabaseIfModelChanges<SurveyDBContext>
    {
        protected override void Seed(SurveyDBContext context)
        {
            var surveys = new List<Survey>
            {
                new Survey() { Name = "Test Survey" }
            };

            //var sections = new List<Section>()
            //{
            //    new Section() { Id = 1, Name = "Text" }
            //};

            //var questions = new List<Question>()
            //{
            //    new Question() { Id = 1, Text = "Test question number 1", Type = QuestionType.Single }
            //};

            //var answers = new List<Answer>
            //{
            //    new Answer() { Id = 1, Text = "Test answer", Exclusive = false }
            //};

            surveys.ForEach(s => context.Surveys.Add(s));
            //sections.ForEach(s => context.Sections.Add(s));
            //questions.ForEach(s => context.Questions.Add(s));
            //answers.ForEach(s => context.Answers.Add(s));

            context.SaveChanges();

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
                Sections = new List<Section>()
                    {
                        new Section()
                        {
                            Id = 1,
                            Name = "Text",
                            Questions = new List<Question>()
                            {
                                new Question()
                                {
                                    Id = 1,
                                    Text = "Test question number 1",
                                    Type = QuestionType.Single,
                                    Answers = new List<Answer>
                                    {
                                        new Answer()
                                        {
                                            Id = 1,
                                            Text = "Test answer",
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