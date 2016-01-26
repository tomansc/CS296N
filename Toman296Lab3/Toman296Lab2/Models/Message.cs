using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Toman296Lab2.Models
{
    public class Message
    {
        private List<string> topics = new List<string>();
        public int MessageID { get; set; }
        public string Subject { get; set; }
        public Member PostingMember { get; set; }
        public DateTime Date { get; set; }
        public string Body { get; set; }
        public List<string> Topics { 
            get 
            { 
                return topics; 
            } 
            set 
            { 
                topics = value; 
            } 
        }
        // Ultimately, there would be
        // some validation here to ensure that only certain values specified by
        // a faraway reference table in the source DB would make it into this 
        // list. For the purpose of a view, however, it doesn't seem necessary 
        // to make a Topic class. That feels overwrought to me. The front-end
        // could still sort by topics without resorting to a Topic class. 
    }
}