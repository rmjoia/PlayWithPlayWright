using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Playwright;
using Newtonsoft.Json;
using PlayWright.Test.Infrastructure;

namespace PlayWright.Client.Pages;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class IndexTest : BlazorTest
{
    [SetUp]
    public async Task Setup()
    {
        await Page.GotoAsync(RootUri.AbsoluteUri);

        await Page.RouteAsync($"**/connect/authorize?**", async route =>
        {
            await route.AbortAsync();
        });

        await Page.RouteAsync($"**/.well-known/openid-configuration**", async route =>
        {
            await route.AbortAsync();
        });

        await Expect(Page.Locator(".loading-progress"))
            .Not.ToBeVisibleAsync(loadingSpinnerTimeout);

        await Expect(Page)
            .ToHaveTitleAsync(new Regex("Play With Playwright Demo page"));

        await Page.WaitForLoadStateAsync();
    }

    [Test]
    public async Task Homepage_DisplaysHomepageText_WhenLoaded()
    {
        await Expect(Page.GetByRole(AriaRole.Heading, new() { Name = "Hello, Playwright!" })).ToBeVisibleAsync();

        await Expect(Page.Locator("p").First)
            .ToHaveTextAsync("This app was created as an example of how to use Playwright with a dotnet solution.");
    }

    [Test]
    public async Task Homepage_DisplaysSidebarWithLinks_WhenLoaded()
    {
        await Expect(Page.Locator(".nav-link.active")).ToHaveTextAsync("Home");

        await Expect(Page.GetByRole(AriaRole.Link, new() { Name = "Report an Issue" }))
            .ToBeVisibleAsync();

        await Expect(Page.GetByRole(AriaRole.Link, new() { Name = "Contact Us" }))
            .ToBeVisibleAsync();

        await Expect(Page.GetByRole(AriaRole.Link, new() { Name = "Fetch Data" }))
            .ToBeVisibleAsync();

        await Expect(Page.GetByRole(AriaRole.Link, new() { Name = "Counter" }))
            .ToBeVisibleAsync();
    }

    [Test]
    public async Task Homepage_DisplaysMainPageLinks_WhenLoaded()
    {
        await Expect(Page.GetByRole(AriaRole.Link, new() { Name = "Playwright logo .Net logo documentation" }))
            .ToHaveTextAsync("documentation");

        await Expect(Page.GetByRole(AriaRole.Link, new() { Name = "Playwright logo .Net logo Playwright dotnet on GitHub" }))
            .ToHaveTextAsync("Playwright dotnet on GitHub");
    }
}