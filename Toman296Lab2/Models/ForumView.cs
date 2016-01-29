using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Toman296Lab2.Models
{
    public class ForumView
    {
        private List<Message> messages = new List<Message>() {};
        [Key]
        public int ForumID { get; set; }
        public string ForumName { get; set; }
        public DateTime LastModified { get; set; }
        public List<Message> Messages
        {
            get { return messages; }
            set { messages = value; }
        }
    }
}