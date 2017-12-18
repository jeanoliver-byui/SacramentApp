using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SacramentApp.Models
{
    public enum HymnOrder
    {
        Open,
        Sacrament,
        Optional,
        Close
    }

    public class Hymn
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int HymnID { get; set; }
        
        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Number")]
        [Range(1, 341)]
        //public int? Number { get; set; }
        public int Number { get; set; }

        [Required]
        [Display(Name = "Hymn Order")]
        public HymnOrder Order { get; set; }
        
    }
}
