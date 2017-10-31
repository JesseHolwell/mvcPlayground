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

            var sections = new List<SectionModel>()
            {
                new SectionModel() { Id = 1, Name = "Text" }
            };

            var questions = new List<QuestionModel>()
            {
                new QuestionModel() { Id = 1, Question = "Test question number 1", Type = QuestionType.Single }
            };

            var answers = new List<AnswerModel>
            {
                new AnswerModel() { Id = 1, Answer = "Test answer", Exclusive = false }
            };

            sections.ForEach(s => context.Sections.Add(s));
            questions.ForEach(s => context.Questions.Add(s));
            surveys.ForEach(s => context.Surveys.Add(s));
            answers.ForEach(s => context.Answers.Add(s));

            context.SaveChanges();

        }
    }
}