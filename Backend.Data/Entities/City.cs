using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Data.Entities
{
    public class City
    {
        [Column(TypeName = "INTEGER")]
        public int CityId { get; set; }

        public string CityName { get; set; }

        [ForeignKey("State")]
        [Column(TypeName = "INTEGER")]
        public int StateId { get; set; }

        [Column(TypeName = "INTEGER")]
        public int? Population { get; set; }

        public virtual State State { get; set; }
    }
}
