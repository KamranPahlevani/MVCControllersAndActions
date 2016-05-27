using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControllersAndActions.Infrastructure
{
    public class StoryLink
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }

        public IList<StoryLink> GetAllStories()
        {
            IList<StoryLink> StoryLinkList = new List<StoryLink>()
            {
                new StoryLink(){Title="First example story", Description="This is the first example story", Url="/Story/1"},
                new StoryLink(){Title="Second example story", Description="This is the second example story", Url="/Story/2"},
                new StoryLink(){Title="Third example story", Description="This is the third example story", Url="/Story/3"}
            };
            return StoryLinkList;
        }
    }
}