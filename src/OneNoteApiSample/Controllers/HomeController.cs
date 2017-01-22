using Microsoft.AspNetCore.Mvc;
using OneNoteApiSample.Auth;

namespace OneNoteApiSample.Controllers
{
	[CookieParsingFilter]
	public class HomeController : Controller
	{
		// Initial HomePage
		public IActionResult Index()
		{
			// If the user is signed in, redirect him to the samples page
			if (AuthContext.IsSignedIn(HttpContext))
			{
				return Redirect(ControllerRoutes.SampleApisPage);
			}

			return View();
		}

		/// <summary>
		/// This is the webpage that will be used to display generic errors - do not delete!
		/// </summary>
		/// <returns></returns>
		public IActionResult Error()
		{
			return View();
		}
	}
}
