using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace college_event.Classes
{

    public class createEvent
    {
        string _event;
        string _category;

        public string Event
        {
            get
            {
                return this._event;
            }
            set
            {
                this._event = value;
            }
        }

        public string category
        {
            get
            {
                return this._category;
            }
            set
            {
                this._category = value;
            }
        }



    }
}