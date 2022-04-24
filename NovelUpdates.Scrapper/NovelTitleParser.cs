using Microsoft.Playwright;
using System;

namespace NovelUpdates.Scrapper
{
    public static class NovelTitleParser
    {
        public static async void PageLoadHandler(object _,
                            IPage p)
        {
            Console.WriteLine("Page loaded!");
            var titleBoxes = p.Locator("div.search_main_box_nu");
            var titleCount = await titleBoxes.CountAsync();
            Console.WriteLine($"Total titleBoxes {titleCount}");

            await titleBoxes.ForEachRow(async it =>
            {

                var titleBoxText = await it.TextContentAsync();
                var titleBoxHtml = await it.InnerHTMLAsync();

                Console.WriteLine("-----TextContent-----");
                Console.WriteLine(titleBoxText);
                Console.WriteLine("-----InnetHTMLContent-----");
                Console.WriteLine(titleBoxHtml);
                Console.WriteLine("-----Tags-----");

                var tags = it.Locator("div.search_body_nu>div.search_genre>a");
                var tagsText = "";
                await tags.ForEachRow(async tag =>
                {
                    var oneTag = await tag.TextContentAsync();
                    tagsText = tagsText + oneTag + " ";
                });
                Console.WriteLine(tagsText);

            });
            // for (int i = 0; i < titleCount; i++)
            // {
            //     var titleBoxText = await titleBoxes.Nth(i).TextContentAsync();
            //     var titleBoxHtml = await titleBoxes.Nth(i).InnerHTMLAsync();

            //     var tags = titleBoxes.Nth(i).Locator("div.search_body_nu>div.search_genre>a");
            //     var tagsCount = await tags.CountAsync();
            //     var tagsText = await tags.TextContentAsync();

            //     Console.WriteLine(tagsCount);

            //     Console.WriteLine(titleBoxText);
            //     Console.WriteLine("--------------");
            //     Console.WriteLine(titleBoxHtml);

            // }
        }
        public static async Task ForEachRow(this ILocator locator, Action<ILocator> action)
        {
            var count = await locator.CountAsync();
            for (int i = 0; i < count; i++)
            {
                action(locator.Nth(i));
            }

        }
    }


}