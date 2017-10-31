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
        public string Name2 { get; set; }
        public string Name3 { get; set; }

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
}