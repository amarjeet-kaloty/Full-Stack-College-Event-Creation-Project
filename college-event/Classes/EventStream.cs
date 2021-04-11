using System;
using System.Collections.Generic;
using System.Web;
using System.Xml;

namespace college_event.Classes
{
    public class EventXML
    {
        public String id;
        public String title;
        public String startDate;
        public String startTime;
        public String endDate;
        public String endTime;
        public String location;
        public String description;
        public String url;

        public EventXML()
        {

        }
    }

    public class EventStream
    {
        XmlTextReader reader;
        public List<EventXML> list = new List<EventXML>();
        EventXML temp;

        public EventStream(String url)
        {
            temp = new EventXML();
            reader = new XmlTextReader(url);
            while (reader.Read())
            {
                switch(reader.NodeType)
                {
                    case XmlNodeType.EndElement:
                        if (reader.Name.Equals("event"))
                        {
                            list.Add(temp);
                            temp = new EventXML();
                        }
                        break;
                    case XmlNodeType.Element:
                        if (reader.Name.Equals("calendar"))
                            break;
                        else if (reader.Name.Equals("id"))
                        {
                            reader.Read();
                            temp.id = reader.Value;
                        }
                        else if (reader.Name.Equals("start_date"))
                        {
                            reader.Read();
                            temp.startDate = reader.Value;
                            //.Substring(5, 16);
                            temp.startTime = reader.Value;
                                //.Substring(17, 25);
                        }
                        else if (reader.Name.Equals("end_date"))
                        {
                            reader.Read();
                            temp.endDate = reader.Value;
                            //.Substring(5, 16);
                            temp.endTime = reader.Value;
                                //.Substring(17, 25);
                        }
                        else if (reader.Name.Equals("location"))
                        {
                            reader.Read();
                            temp.location = reader.Value;
                        }
                        else if (reader.Name.Equals("title"))
                        {
                            reader.Read();
                            temp.title = reader.Value;
                        }
                        else if (reader.Name.Equals("description"))
                        {
                            reader.Read();
                            switch (reader.NodeType)
                            { 
                                case XmlNodeType.CDATA:
                                    temp.description = HttpUtility.HtmlDecode(reader.Value);
                                    break;
                            }
                        }
                        else if (reader.Name.Equals("webpage"))
                        {
                            reader.Read();
                            if (reader.Name.Equals("url"))
                                temp.url = reader.Value;
                        }

                        break;
                }
            }
        }
    }
}