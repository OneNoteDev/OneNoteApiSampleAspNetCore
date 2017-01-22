using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc.Filters;

namespace OneNoteApiSample.Auth
{
	public class CookieParsingFilter : ActionFilterAttribute
	{
		public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
		{
			AuthTokenProperties tokenProperties = CookieUtils.GetCookieFromRequest(context.HttpContext.Request);

			if (tokenProperties != null)
			{
				// Check if tokens are expired
				if (DateTime.UtcNow > tokenProperties.Expiry)
				{
					// Renew them
					tokenProperties = await MsaAuthUtils.Instance.ExchangeRefreshTokenForAuthInfo(tokenProperties.RefreshToken);
				}

				AuthContext.SetContext(context.HttpContext, tokenProperties);
			}

			await next();
		}
	}
}
