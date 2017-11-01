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
}