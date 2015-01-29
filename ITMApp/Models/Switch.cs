using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITMApp.Models
{
    public class Switch
    {
        public int switchID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Status> Statuses { get; set; }
    }
}