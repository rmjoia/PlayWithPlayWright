using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Playwright;
using PlayWright.Test.Infrastructure;

namespace PlayWright.Client.Pages;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class SomethingTest : BlazorTest
{
    [SetUp]
    public async Task Setup()
    {
        await Page.GotoAsync(RootUri.AbsoluteUri);

        await Expect(Page.Locator(".loading-progress")).Not.ToBeVisibleAsync(loadingSpinnerTimeout);

        await Expect(Page.GetByRole(AriaRole.Link, new() { Name = "PlayWithPlayWright" })).ToBeVisibleAsync();

        await Page.WaitForLoadStateAsync();
    }

    [Test]
    public async Task Homepage_DisplaysCorrectTitle_WhenLoaded()
    {
        await Expect(Page).ToHaveTitleAsync(new Regex("PlayWithPlayWright"));

        await Expect(Page.Locator(".nav-link.active")).ToHaveTextAsync("Home");

        await Expect(Page.GetByRole(AriaRole.Link, new() { Name = "Report an Issue" })).ToBeVisibleAsync();
        await Expect(Page.GetByRole(AriaRole.Link, new() { Name = "Contact Us" })).ToBeVisibleAsync();
        await Expect(Page.GetByRole(AriaRole.Link, new() { Name = "Fetch Data" })).ToBeVisibleAsync();
        await Expect(Page.GetByRole(AriaRole.Link, new() { Name = "Counter" })).ToBeVisibleAsync();
    }
}