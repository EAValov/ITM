using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace ITMApp.Models
{
   
    [Table("switch")]
    public partial class _switch
    {
        public _switch()
        {
            status = new HashSet<status>();
        }

        [Key]
        public int switchID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public virtual ICollection<status> status { get; set; }
    }
}
