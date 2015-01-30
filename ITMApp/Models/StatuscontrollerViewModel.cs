using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITMApp.Models
{
    public class StatusControllerViewModel 
    {
        public List<_switch> DownSwitches { get; set; }
        public List<_switch> UpSwitches { get; set; }
    }
}