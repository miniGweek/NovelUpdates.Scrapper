using System.Collections.Concurrent;
using Microsoft.Playwright;

namespace NovelUpdates.Scrapper
{
    public static class NovelTitleParser
    {
        public static async void PageLoadHandler(object _,
                            IPage p)
        {
            Console.WriteLine("Page loaded!");
            var titleBoxes = p.Locator("div.search_main_box_nu");

            var titleBoxCount = await titleBoxes.CountAsync();
            for(int i = 0; i < titleBoxCount; i++)
            {
                var titleAnchor = titleBoxes.Nth(i).Locator("div.search_body_nu > div.search_title > a");
                var tags = titleBoxes.Nth(i).Locator("div.search_body_nu > div.search_genre > a");
                var tagsCount = await tags.CountAsync();

                var tagsText = "";
                for (int tagIndex = 0; tagIndex < tagsCount; tagIndex++)
                {
                    tagsText += $"{await tags.Nth(tagIndex).TextContentAsync()} ";
                }

                var titleAnchorText = await titleAnchor.TextContentAsync();
                Console.WriteLine($"Title: {titleAnchorText} - Tags: {tagsText}");
            }
        }
    }
}