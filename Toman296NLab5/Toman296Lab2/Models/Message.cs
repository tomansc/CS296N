using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Toman296Lab2.Models
{
    public class Message
    {
        //private List<string> topics = new List<string>(); I'll come back to this once I have a more secure grasp of why this list isn't holding onto its items when being passed to a View in a Message or MessageView object. I suspect that it *might* involve the fact that I didn't explcitly add the Messages straight to the DBContext.
        public int MessageID { get; set; }

        [Required(ErrorMessage ="The subject of your message should not be empty, nor should it exceed 150 characters.")]
        [StringLength(150, MinimumLength =8)]
        [Display(Name ="Title of your post: ")]
        public string Subject { get; set; }
        public int MemberID { get; set; } 
        public DateTime Date { get; set; }
        [Required(ErrorMessage ="The body of your message should not be empty, nor should it exceed 1,500 characters.")]
        [StringLength(1500, MinimumLength =20)]
        [Display(Name ="Body of your post: ")]
        public string Body { get; set; }
        [Display(Name ="Topical keyword to help others find your post (eventually): ")]
        public string Topic { get; set; } //A keyword for now. Multiple KWs later.
           
        // Ultimately, there would be
        // some validation here to ensure that only certain values specified by
        // a faraway reference table in the source DB would make it into this 
        // list. For the purpose of a view, however, it doesn't seem necessary 
        // to make a Topic class. That feels overwrought to me. The front-end
        // could still sort by topics without resorting to a Topic class. 
    }
}