using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Toman296Lab2.Models
{
    public class MessageView
    {
        private Member postingMember = new Member();

        private List<string> topics = new List<string>();
        public int MessageViewID { get; set; }
        public int MessageID { get; set; }
        public string Subject { get; set; }
        public Member PostingMember { get { return postingMember; } set { postingMember = value; } } 
        public DateTime Date { get; set; }
        public string Body { get; set; }
        public List<string> Topics
        {
            get
            {
                return topics;
            }
            set
            {
                topics = value;
            }
        }
    }
}