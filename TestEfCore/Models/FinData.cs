using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace testEfCore.Models
{
    public class FinData : BaseEntity
    {
        
        public string PERIOD { get; set; }
        public string ANAACCCD { get; set; }
        public string GENACCCD { get; set; }
        public string ENVIRO { get; set; }
        public string FOLDER { get; set; }
        public int? PROJECT { get; set; }
        public int? PERSON { get; set; }
        public decimal? REALIZED { get; set; }
        public string ACCDS1AC { get; set; }
    }
}




