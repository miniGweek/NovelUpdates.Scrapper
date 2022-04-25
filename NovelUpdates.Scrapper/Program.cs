// See https://aka.ms/new-console-template for more information
using Microsoft.Playwright;
using System.Threading.Tasks;
using NovelUpdates.Scrapper;

Console.WriteLine("Hello, World!");

using var playwright = await Playwright.CreateAsync();
await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
{
    Headless = false,
    SlowMo = 50,
});

//await using var browser = await playwright.Chromium.LaunchAsync();
var page = await browser.NewPageAsync();
page.Load += NovelTitleParser.PageLoadHandler;

await page.GotoAsync("https://www.novelupdates.com/series/");
//await page.GotoAsync("file:///C:/Users/Rahul/Downloads/Series%20-%20Novel%20Updates.html");
await Task.Delay(600000);