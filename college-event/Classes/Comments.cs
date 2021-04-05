using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace college_event.Classes
{
    public class Comments
    {
        public String Uid { get; set; }
        public int Event_id { get; set; }
        public int Score { get; set; }
        public String Text { get; set; }
    }
}