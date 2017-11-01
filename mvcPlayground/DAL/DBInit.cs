using mvcPlayground.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvcPlayground.DAL
{
    //public class DBInit : System.Data.Entity.DropCreateDatabaseIfModelChanges<SurveyDBContext>
    public class DBInit : System.Data.Entity.DropCreateDatabaseAlways<SurveyDBContext>
    {
        protected override void Seed(SurveyDBContext context)
        {
            var surveys = new List<Survey>
            {
                new Survey()
                {
                    Name = "Test Survey" ,
                    Sections = new List<Section>()
                    {
                        new Section()
                        {
                            Name = "Text 1",
                            Questions = new List<Question>()
                            {
                                new Question
                                {
                                    Text = "Test question number 1", Type = QuestionType.Single,
                                    Answers = new List<Answer>
                                    {
                                        new Answer() { Text = "Test answer 1", Exclusive = false },
                                        new Answer() { Text = "Test answer 2", Exclusive = false },
                                        new Answer() { Text = "Test answer 3", Exclusive = false },
                                        new Answer() { Text = "Other", Exclusive = true },
                                    }
                                },
                                new Question
                                {
                                    Text = "Test question number 2", Type = QuestionType.Single,
                                    Answers = new List<Answer>
                                    {
                                        new Answer() { Text = "Test answer 1", Exclusive = false },
                                        new Answer() { Text = "Test answer 2", Exclusive = false },
                                        new Answer() { Text = "Test answer 3", Exclusive = false },
                                        new Answer() { Text = "Other", Exclusive = true },
                                    }
                                }
                            }
                        },
                        new Section()
                        {
                            Name = "Text 2",
                            Questions = new List<Question>()
                            {
                                new Question
                                {
                                    Text = "Test question number 1", Type = QuestionType.Single,
                                    Answers = new List<Answer>
                                    {
                                        new Answer() { Text = "Test answer 1", Exclusive = false },
                                        new Answer() { Text = "Test answer 2", Exclusive = false },
                                        new Answer() { Text = "Test answer 3", Exclusive = false },
                                        new Answer() { Text = "Other", Exclusive = true },
                                    }
                                },
                                new Question
                                {
                                    Text = "Test question number 2", Type = QuestionType.Single,
                                    Answers = new List<Answer>
                                    {
                                        new Answer() { Text = "Test answer 1", Exclusive = false },
                                        new Answer() { Text = "Test answer 2", Exclusive = false },
                                        new Answer() { Text = "Test answer 3", Exclusive = false },
                                        new Answer() { Text = "Other", Exclusive = true },
                                    }
                                }
                            }
                        }
                        ,
                        new Section()
                        {
                            Name = "Empty Section"
                        }
                    }
                },
                new Survey()
                {
                    Name = "Empty Survey"
                }
            };

            surveys.ForEach(s => context.Surveys.Add(s));

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