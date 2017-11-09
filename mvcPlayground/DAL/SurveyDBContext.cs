using mvcPlayground.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace mvcPlayground.DAL
{
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

    public static class DBHelper
    {
        public static bool NormalizeSectionOrder(int surveyId, SurveyDBContext db)
        {
            var sections = db.Sections.Where(x => x.SurveyId == surveyId).OrderBy(x => x.Order).ToList();
            if (sections != null && sections.Count() > 0)
            {
                LinkedList<Section> list2 = new LinkedList<Section>();

                list2.AddFirst(sections[0]);
                for (var i = 1; i < sections.Count(); i++)
                    list2.AddLast(sections[i]);

                var counter = 0;
                foreach (var v in list2)
                    v.Order = counter++;

                return db.SaveChanges() > 0;
            }
            return false;
        }
    }
}