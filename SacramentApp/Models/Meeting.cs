using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SacramentApp.Models
{
    public class Meeting
    {
        public int MeetingID { get; set; }
        
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd MMMM, yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date")]
        public DateTime MeetingDate { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Conductor")]
        public string Conductor { get; set; }

        public ICollection<Hymn> Hymns { get; set; }
        public ICollection<Prayer> Prayers { get; set; }
        public ICollection<Speaker> Speakers { get; set; }
    }
}
