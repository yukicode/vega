using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Vega.Models {
    [Table("Models")]
    public class Model {
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public int Id { get; set; }

        //navigation property
        public Maker Maker { get; set; }
        //foreign key
        public int MakerId { get; set; }
    }
}