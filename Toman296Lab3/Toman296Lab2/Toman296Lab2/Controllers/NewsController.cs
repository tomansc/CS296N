using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Toman296Lab2.Models;

namespace Toman296Lab2.Controllers
{
    public class NewsController : Controller
    {
        // GET: News
        public ActionResult Archive()
        {
            NewsItem n1 = new NewsItem
            {
                Author = "Macaroni McGillavroy",
                Date = "Nov. 12, 2013",
                Title = "Whatcom County couple fined after llama farm debacle",
                Copy = "DEMING, WA -- Following last week's highly publicized security breach at their Deming-area llama farm, Alpaca Johnson, 68, and Henrietta Forsyth, 83, have been fined $2.50 by Whatcom County authorities for failing to contain their woolly companions. Nearly 30 of the amiable mammals escaped into the rural backwoods lining Hwy. 9 after Forsyth reportedly neglected to latch the southern gate on the property. Neighbors reported finding llamas in locations as diverse as a milking barn, grocery store, laundry room, and even the walk-in fridge of a local dive bar."
            };
            NewsItem n2 = new NewsItem
            {
                Author = "Marbles McConaghey",
                Date = "Jan. 12, 2016",
                Title = "City of Bellingham announces micro-park initiative",
                Copy = "BELLINGHAM, WA -- After the success of Bellingham's 2012 mini-park project that converted unused medians and concrete expanses around the downtown area into miniature parks complete with a bench, vegetation, and stones from the Nooksack River, the city announced Wednesday a new plan to revitalize neglected rain gutters, sidewalk cracks, potholes, and other such minuscule spaces with \"micro-parks\". Mayor Holly Jolly unveiled the city council's plan with great enthusiasm at a sparsely attended Town Hall meeting to scores of groans, and many an eye were reportedly rolled in unison."
            };
            NewsItem n3 = new NewsItem
            {
                Author = "Macaroni McGillavroy",
                Date = "Dec. 30, 2015",
                Title = "Yet another craft brewery to call downtown Bellingham home",
                Copy = "BELLINGHAM, WA -- If Bellinghamsters weren't already content with the 48 breweries already headquartered in the City of Subdued Excitement, perhaps they'll warm to Hop Snobbery Brewery, a micro-micro-brewery slated to open up on State Street alongside 12 other microbreweries just in time for the new year on Jan. 5, 2016. Owner Chip \"Homebro\" Homebrew claims to have invented the concept of the micro-micro-brew, which uses pint-sized casks and kegs to ensure \"the smallest and most delicately curated batches available on the market today.\" He'll reportedly be serving up tiny ales in equally tiny mugs."
            };
            List<NewsItem> newsList = new List<NewsItem>() { n1, n2, n3};
            return View(newsList);
        }

        public ActionResult Recent()
        {
            NewsItem n1 = new NewsItem
            {
                Author = "Macaroni McGillavroy",
                Date = "Jan. 16, 2016",
                Title = "News item falls from sky, injures 1",
                Copy = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed vestibulum imperdiet dui nec congue. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam ex dui, volutpat ut arcu sit amet, vestibulum efficitur risus. Quisque malesuada vel justo vitae pretium. Vivamus tincidunt urna ut est mattis auctor. Cras dignissim, leo et porttitor dapibus, odio dolor volutpat tellus, et posuere lorem purus et enim. Sed augue arcu, fringilla nec massa placerat, tempor tristique quam. Proin pretium eleifend tincidunt. Suspendisse eu consequat lorem. Morbi interdum dictum est, vitae rutrum justo ullamcorper vel. Cras scelerisque sollicitudin ipsum. Vivamus euismod nunc id sapien accumsan pellentesque a nec erat. Proin quis vulputate mi. Cras semper at tortor ut convallis."
            };
            NewsItem n2 = new NewsItem
            {
                Author = "Marbles McConaghey",
                Date = "Jan. 18, 2016",
                Title = "Man in peanut suit taken into custody for disorderly conduct",
                Copy = "Nam ornare pellentesque facilisis. Ut cursus elementum magna vel pharetra. Donec rutrum nibh sit amet aliquam tempus. Etiam iaculis leo feugiat eros suscipit interdum. Suspendisse malesuada nunc sit amet quam laoreet hendrerit. Maecenas aliquam ex sit amet leo euismod suscipit. Nam mattis lorem id risus mollis, vitae venenatis risus fermentum. Maecenas hendrerit lacinia pulvinar. Suspendisse in libero sed sem condimentum dignissim ut quis lectus. Fusce scelerisque placerat purus, id pharetra lectus sodales euismod. Quisque a imperdiet arcu. Vivamus ultricies sapien quis erat vulputate interdum. In quam mi, aliquet sed ultrices sed, tempus et libero."
            };
            NewsItem n3 = new NewsItem
            {
                Author = "Snooze McFitz",
                Date = "Jan. 20, 2016",
                Title = "Series of minor earthquakes leaves Bellinghamsters feeling shaken up",
                Copy = "Ut sed volutpat ante, vitae consectetur elit. Mauris a facilisis nisi. Nulla tincidunt mauris risus, non luctus odio interdum at. Duis feugiat enim metus, id mattis nunc porta in. Donec interdum felis id volutpat convallis. In cursus bibendum ante vitae facilisis. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam vehicula dui eget nunc pulvinar congue. In vehicula lorem ut maximus laoreet. Morbi gravida magna turpis, vitae hendrerit nisi varius vitae. Morbi ac augue nunc. Phasellus ut blandit magna, ac imperdiet tellus. Pellentesque non urna sit amet neque tincidunt auctor. In laoreet odio semper iaculis tincidunt."
            };

            List<NewsItem> newsList = new List<NewsItem> { n1, n2, n3 };
            return View(newsList);
        }
    }
}