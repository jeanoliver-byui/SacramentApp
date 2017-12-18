using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SacramentApp.Models
{
    public class Speaker
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SpeakerID { get; set; }
        
        public const int SpeakerOrder = 3;

        [Required]
        [StringLength(50)]
        [Display(Name = "Speaker Name")]
        public string SpeakerName { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Subject")]
        public string Subject { get; set; }

        [Required]
        [Display(Name = "Speaker Order")]
        [Range(0, SpeakerOrder)]
        public int Order { get; set; }
        
    }
}
