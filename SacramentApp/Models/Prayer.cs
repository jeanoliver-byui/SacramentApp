using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SacramentApp.Models
{
    public enum PrayerOrder
    {
        Open,
        Close
    }

    public class Prayer
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PrayerID { get; set; }
        
        [Required]
        [StringLength(50)]
        [Display(Name = "Prayer")]
        public string PrayerName { get; set; }

        [Required]
        [Display(Name = "Prayer Order")]
        public PrayerOrder Order { get; set; }
        
    }
}
