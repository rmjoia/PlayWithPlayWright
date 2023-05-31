# PlayWithPlayWright

Example and Demo of how to use PlayWright with dotnet, GitHub Actions and Azure DevOps Pipelines

# How to get it working on your machine?

Clone the repo to your favourite folder, and while you're at it, use also your favourite IDE or Code Editor to open the solution.

## Playwright Tests
The Playwight tests in this solution can be found under the Playwright Project.
Extra code `Infrastructure/BlazorTest.cs` was added to stub the HTTP Client and run the tests without using a real HTTP Client, this is not part of the bundle that comes with playwright.

## Installing .Net
If you don't have it yet or want to upgrade your .Net version, [Download .Net](https://dotnet.microsoft.com/en-us/download) might be a good place to start alternatively you can also use [Install .Net on Windows, Linux and MacOS](https://learn.microsoft.com/en-us/dotnet/core/install/)

## Visual Studio
Run the solution to see how it looks or go directly to the tests.

## Visual Studio Code
You might use the "Run and Debug" option to run the solution to see how it looks or go directly to the tests.
Alternatively you can run `dotnet run` from the terminal and if you want to develop while coding, `dotnet watch run` might be handy.

## Powershell
If you need to install PowerShell to run the codegen, you might want to refer to [Install PowerShell on Windows, Linux, and macOS](https://learn.microsoft.com/en-us/powershell/scripting/install/installing-powershell-on-macos?view=powershell-7.3)

## Playwright Installation
But wait! Before running Playwright or the codegen, we need to install it first! refer to Playwright's .Net [Installation](https://playwright.dev/dotnet/docs/intro) to get you started!

## Playwright Codegen
If you never used it before, give it a go! More on what is it and how to run information can be found @ [Test Generator](https://playwright.dev/dotnet/docs/codegen-intro)
Spin the solution with the IDE, `dotnet run`, `dotnet watch run` or however you like and spin the codegen!

For this project soemthing along the lines of `pwsh ./PlayWithPlayWright/Playwright/bin/Debug/net7.0/playwright.ps1 codegen https://localhost:7201` is what you need...

## Playwright run settings
A sample `.runsettings` file was added to get you started, one possible way to use it is to configure Visual Studio to use the settings file, the other is when running your tests in the command line: More information @ [Configure unit tests by using a .runsettings file](https://learn.microsoft.com/en-us/visualstudio/test/configure-unit-tests-by-using-a-dot-runsettings-file?view=vs-2022) for Visual Studio and [dotnet test](https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-test) for the CLI.
If you're like me, and I know I am, you just want to try it, so, this should work `dotnet test --settings ./PlayWithPlayWright/Playwright/.runsettings`
You can use the settings file, for instance, to slow down the test runner by changing the `SlowMo` value or if you want to see the "magic happening" turn off the headless mode, also helpfull for debugging by setting `healess` to `false`;