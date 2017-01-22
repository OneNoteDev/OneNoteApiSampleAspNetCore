using Microsoft.AspNetCore.Mvc;
using OneNoteApiSample.Auth;
using OneNoteApiSample.SampleApis;

namespace OneNoteApiSample.Controllers
{
	public class LogoutController : Controller
	{
		// Initial HomePage
		public IActionResult Index()
		{
			CookieUtils.ClearCookies(Response);

			return Redirect(ControllerRoutes.HomePage);
		}
	}
}
