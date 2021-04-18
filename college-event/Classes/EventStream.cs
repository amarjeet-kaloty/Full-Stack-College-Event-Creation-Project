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
        public TimeSpan startTime;
        public String endDate;
        public TimeSpan endTime;
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
        String url;

        public EventStream(String url)
        {
            this.url = url;
        }

        public List<EventXML> getEvents()
        {
            temp = new EventXML();
            reader = new XmlTextReader(this.url);
            while (reader.Read())
            {
                switch (reader.NodeType)
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
                            
                            temp.startDate = reader.Value.Substring(5, 11);

                            String t = reader.Value.Substring(17, 8);
                            TimeSpan ts = new TimeSpan(Int32.Parse(t.Substring(0, 2)), Int32.Parse(t.Substring(3, 2)), Int32.Parse(t.Substring(6, 2)));
                            temp.startTime = ts;
                            
                        }
                        else if (reader.Name.Equals("end_date"))
                        {
                            reader.Read();
                            temp.endDate = reader.Value.Substring(5, 11);

                            String t = reader.Value.Substring(17, 8);
                            TimeSpan ts = new TimeSpan(Int32.Parse(t.Substring(0, 2)), Int32.Parse(t.Substring(3, 2)), Int32.Parse(t.Substring(6, 2)));
                            temp.endTime = ts;
                            
                        }
                        else if (reader.Name.Equals("location"))
                        {
                            reader.Read();
                            temp.location = reader.Value;
                        }
                        else if (reader.Name.Equals("title"))
                        {
                            reader.Read();
                            if (reader.Value.Equals("Events at UCF") || reader.Value.Equals("Event Instance url"))
                                break;

                            
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

            return list;
        }
    }
}