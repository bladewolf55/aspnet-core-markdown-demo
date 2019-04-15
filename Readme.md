![](aspnet-core-demo-logo.png)

<sup>I made the logo using [Inkscape](https://inkscape.org/).</sup>
# ASP.NET Core 2.2 Demo Application

## About
This is a simplistic demo using ASP.NET Core. The goal is to provide a sample of the work I did learning .NET Core in about a week. 
I wish that was super-impressive, but .NET Core makes a lot of sense based on what came before, and it wasn't hard to get something working. 
I read a couple of Syncfusion's [Succintly](https://www.syncfusion.com/ebooks) books, which helped a lot. Microsoft's documentation is also a big help.

What the app does: As Markdown is entered, it is sent via AJAX to a WebApi service that converts the Markdown to HTML, which is returned and displayed.

## Techniques
Several techniques are explored in the source code, even if not shown in the project.

**Responsive Design**  
There isn't *much* web development here, but I did make sure it looked decent on a phone, and yet side-by-side in a browser. On Chrome, it's easy to test via F12 then click Toggle Device Toolbar.

**Environment Configuration**  
The .NET Core configuration system is impressive and complex. I have a special place in my heart for improving configuration since I wrote a NuGet package to help with that: [DeftConfig](https://www.nuget.org/packages/DeftConfig/).

I did the simplest thing, which was to add the Web API Url to appsettings.Development.json. I like the ability to directly access the Configuration intance from a Razor page.

**Pipelining**  
This isn't a technique so much as a requirement. The influence of OWIN in ASP.NET WebApi is unmistakable. The clarity of using Project.cs and Startup.cs is a joy.

**Synchronous AJAX**  
This is the *wrong* way to do it, and I know it. But for a demo, it was more important to show getting data from a service.

**Textarea Editing**  
The textarea's Tab keydown is overriden to stay within the textarea.
*   I found and used sample code for overriding the tab key. I don't feel bad about that.
    *   (OK, I could have figure it out. I've dealt with key press events since Visual Basic 5)

**Markdown Parsing**  
I used the terrific Markdown parser [markdig](https://github.com/lunet-io/markdig).

## Other Markdown Examples

### Heading 3
Each heading is styled, of course.

Bullets and Numbering work. 
*   Call me old-fashioned, but I like building software this way:
    1.  Worry about functionality first.
    2.  Get the simplest foundations working.
    3.  Build on the foundations, expecting significant refactoring and changes.

That's simple enough[^1].

[^1]: And not old-fashioned at all.

#### Heading 4
Sorry, no code syntax styling.

```csharp
public string WhyGit() {
	return @@"
Why do I insist on using Git? Because I've used version control since Visual SourceSafe. 
Git has its problems, but having used its branch-merge model I never want to go back to 
centralized systems.";
```
