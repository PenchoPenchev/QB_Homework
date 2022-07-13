
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Data.Entities
{
    public class Country
    {
        [Column(TypeName = "INTEGER")]
        public int CountryId { get; set; }

        public string CountryName { get; set; }
    }
}
