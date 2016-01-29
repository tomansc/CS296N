using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Toman296Lab2.Models
{
    public class ForumViewDBInitializer : DropCreateDatabaseAlways<Toman296Lab2Context>
    {
        protected override void Seed(Toman296Lab2Context context)
        {
            Member firstMember = new Member { MemberID = 1, MemberEmail = "samantha.toman@gmail.com", MemberUName = "tomansc" };
            Member secondMember = new Member { MemberID = 2, MemberEmail = "macaroni@cheese.com", MemberUName = "mcgillavroy" };
            context.Member.Add(firstMember);
            context.Member.Add(secondMember);

            Message m1 = new Message { Topic = "Garage sale", Date = new DateTime(2016, 2, 10), MessageID = 11, MemberID = 2, Body = "Does anyone need llama pelts, matroyshka dolls, Trapper Keepers in mint condition, or other odd tchotchkes? Come on down to the Elks Club this Saturday for bizarre knick-knacks odder than anything your imagination can conjure up.", Subject="Sale: Weird and Delightful Goods -- for Cheap!"};
            Message m2 = new Message { Topic = "Neighborhood watch", Date = new DateTime(2016, 1, 30), MessageID = 12, MemberID = 2, Body = "There have been Sasquatch sightings reported all around Sudden Valley. Grab your cameras, a six-pack of micro-cans from Hop Snobbery Brewery, and get ready to place some bets with your neighbors as we all doubt our sanity for an afternoon.", Subject = "Sasquatch Watch THIS SATURDAY" };
            Message m3 = new Message { Topic = "Volunteer", Date = new DateTime(2016, 3, 14), MessageID = 13, MemberID = 1, Body = "Come on down to the Bellingham Farmers' Market in March to volunteer at PoultryFest. Volunteers are need particularly for the chicken fashion show.", Subject = "PoultryFest seeking volunteers" };
            Message m4 = new Message { Topic = "Skills share", Date = new DateTime(2016, 4, 2), MessageID = 14, MemberID = 1, Body = "WCC is looking to host a series of night classes on programming basics, and what better way to dive in than to make your own website? Bring snacks.", Subject = "Pro bono programming courses -- make a website!" };

            ForumView f1 = new ForumView();
            f1.LastModified = DateTime.Now;
            f1.ForumID = 321;
            f1.ForumName = "Test forum for Bellingham site";
            f1.Messages.Add(m1);
            f1.Messages.Add(m2);
            f1.Messages.Add(m3);
            f1.Messages.Add(m4);
            context.ForumViews.Add(f1);
            base.Seed(context); // Messages are still in there at this point...
        }
    }
}