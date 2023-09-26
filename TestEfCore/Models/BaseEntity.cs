using System.ComponentModel.DataAnnotations;

namespace testEfCore.Models
{
    public class BaseEntity
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }
}
