using ITMApp.DBContext;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace ITMApp.Models
{
    public partial class status
    {
        [Key]
        public int statusID { get; set; }

        public int? switchID { get; set; }

        public DateTime datetime { get; set; }

        [Required]
        [StringLength(2)]
        public string action { get; set; }

        public virtual _switch _switch { get; set; }
    }
}
