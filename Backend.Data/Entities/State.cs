using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Data.Entities
{
    public class State
    {
        public State()
        {
            this.Countries = new HashSet<Country>();
        }

        [Column(TypeName = "INTEGER")]
        public int StateId { get; set; }

        public string StateName { get; set; }

        [ForeignKey("Country")]
        [Column(TypeName = "INTEGER")]
        public int CountryId { get; set; }

        public virtual Country Country { get; set; }

        public virtual ICollection<Country> Countries { get; set; }
    }
}
