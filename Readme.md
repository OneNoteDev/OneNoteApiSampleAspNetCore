## OneNote service API ASP.NET core sample

Created by Microsoft Corporation, 2017. Provided As-is without warranty. Trademarks mentioned here are the property of their owners.

DEMO: http://onenoteapisamplenetcore.azurewebsites.net/

### Intro
* This is a small sample that shows how to use the OneNote API from an ASP.NET server.
* It is configured to work for OneDrive only, but swapping AppIds/Auth urls would make it work with O365

### Content

You can find additional documentation at the links below.

* Create Pages: 
    * [POST simple HTML to a new OneNote Quick Notes page](http://msdn.microsoft.com/EN-US/library/office/dn575428.aspx)
* Query and Search Pages:
    *  [GET a paginated list of all pages in OneNote](http://dev.onenote.com/docs#/reference/get-pages)
* Manage Notebooks and Sections:
    * [GET a list of all notebooks](http://dev.onenote.com/docs#/reference/get-notebooks)
    * [GET a list of all sections](http://dev.onenote.com/docs#/reference/get-sections)

### Prerequisites

**Tools and Libraries** you will need to download, install, and configure for your development environment. 
* [Visual Studio 2015 Update 3 or later](http://www.visualstudio.com/en-us/downloads). 
* [ASP.NET Core](https://www.asp.net/core)

* **NuGet packages** used in the sample. These are handled using the package manager, as described in the setup instructions. These should update automatically at build time; if not, make sure your NuGet package manager is up-to-date. You can learn more about the packages we used at the links below.
    * [Newtonsoft Json.NET package](http://newtonsoft.com/) provides Json parsing utilities.
    * Other Nuget packages from Microsoft, listed in project.json

### Accounts
**To use this Code Sample in your own Microsoft Account based app, be sure to do the following:**
* As the developer, you'll need to [have a Microsoft account and get a client ID string](http://msdn.microsoft.com/EN-US/library/office/dn575426.aspx) so your app can authenticate. Get a client ID string and copy it into the file under [.../AspNetCoreSample/src/OneNoteApiSample/Config.cs](https://github.com/OneNoteDev/OneNoteAPISampleWinUniversal/blob/master/OneNoteServiceSamplesWinUniversal.Shared/OneNoteApi/LiveIdAuth.cs#L54) (~line 54).
* Use the least permissible scopes by editing [.../AspNetCoreSample/src/OneNoteApiSample/Config.cs]
**To use this Code Sample in your own Microsoft Office 365 based app, refer to the details in the blog [Support for work and school notebooks on Office 365](http://blogs.msdn.com/b/onenotedev/archive/2015/04/30/support-for-work-and-school-notebooks-on-office-365-in-preview.aspx)

### Using the sample

After you've set up your development tools, and installed the prerequisites listed above,...

1. Download the repository as a ZIP file to your local computer, and extract the files. Or, clone the repository into a local copy of Git.
2. Open the project (.sln file) in Visual Studio.
3. It is highly recommended that you get your own client ID, secret and redirect uri and copy it into
	[.../OneNoteServiceSamplesAspNetCore/src/Config.cs](TODO)
4. Make a change to your machine (In windows, this is hosts file change) so the domain "onenoteapisamplenetcore.azurewebsites.net" (or the domain for the redirect URI you've chosen for your app) resolves to localhost or "127.0.0.1". Otherwise, authentication won't work.
5. Build and run the application (F5)

#### Note
As a sample, and for simplicity, this sample does not follow best practices for an application in Production. If you intent to ship this code, we recommend doing the following:

* Never check in app secrets to your repository
* Require HTTPS throughout your site
* Don't store unencrypted refresh tokens in cookies

### Version Info

| Date | Change |
|------|------|
| January 2017 | Initial public release for this code sample. |
  
### Learning More

* Visit the [dev.onenote.com](http://dev.onenote.com) Dev Center
* Contact us on [StackOverflow (tagged OneNote)](http://go.microsoft.com/fwlink/?LinkID=390182)
* Follow us on [Twitter @onenotedev](http://www.twitter.com/onenotedev)
* Read our [OneNote Developer blog](http://go.microsoft.com/fwlink/?LinkID=390183)
* Explore the API using the [apigee.com interactive console](http://go.microsoft.com/fwlink/?LinkID=392871) OR the [apiary.io interactive console](http://dev.onenote.com/docs).
Also, see the [short overview/tutorial](http://go.microsoft.com/fwlink/?LinkID=390179). 
* [API Reference](http://msdn.microsoft.com/en-us/library/office/dn575437.aspx) documentation
* [Debugging / Troubleshooting](http://msdn.microsoft.com/EN-US/library/office/dn575430.aspx)
* [Getting Started](http://go.microsoft.com/fwlink/?LinkID=331026) with the OneNote service API

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/). For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments.
\ No newline at end of file