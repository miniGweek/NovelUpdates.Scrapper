// See https://aka.ms/new-console-template for more information
using Microsoft.Playwright;
using System.Threading.Tasks;
using NovelUpdates.Scrapper;

Console.WriteLine("Hello, World!");

using var playwright = await Playwright.CreateAsync();
await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
{
    Headless = false,
    SlowMo = 500,
});

//await using var browser = await playwright.Chromium.LaunchAsync();
var page = await browser.NewPageAsync();
page.Load += NovelTitleParser.PageLoadHandler;
await page.GotoAsync("https://www.novelupdates.com/series/");