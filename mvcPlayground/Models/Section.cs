using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvcPlayground.Models
{
    public class Section
    {
        public Section()
        {
        }

        public int Id { get; internal set; }
        public int SurveyId { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }

        public virtual ICollection<Question> Questions { get; set; }
    }
}