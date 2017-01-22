using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OneNoteApiSample.Auth;
using OneNoteApiSample.SampleApis;

namespace OneNoteApiSample.Controllers
{
	[CookieParsingFilter]
	public class SampleApisController : Controller
	{
		// Initial HomePage
		public IActionResult Index()
		{
			// If the user is not signed in, redirect him to home
			if (!AuthContext.IsSignedIn(HttpContext))
			{
				Redirect(ControllerRoutes.HomePage);
			}

			return View(SampleApiList.SampleApis);
		}

		// RunApi page
		[ActionName("runapi")]
		public async Task<IActionResult> RunApi(string name)
		{
			// If the user is not signed in, redirect him to home
			if (!AuthContext.IsSignedIn(HttpContext))
			{
				Redirect(ControllerRoutes.HomePage);
			}

			SampleApi sampleApi = SampleApiList.GetSampleApiByName(name);

			SampleApiResult result = await SampleApiRunner.ExecuteApiCall(HttpContext, sampleApi);

			return View(result);
		}
	}
}
