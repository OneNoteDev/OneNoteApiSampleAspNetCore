using System;

using Microsoft.AspNetCore.Http;

using Newtonsoft.Json;

namespace OneNoteApiSample.Auth
{
	// TODO: Another option when implementing this in asp.net core is cookie identity middleware. For this sample, we decided to use the cookie ourselves
	// In production code, it is best to encrypt cookies. Storing the tokens in the cookie as below is not good practice.
	public static class CookieUtils
	{
		private const string AuthCookieName = "OneNoteApiSampleAuthCookie";

		public static void StoreInCookie(AuthTokenProperties tokenInformation, HttpResponse response)
		{
			string serializedJson = JsonConvert.SerializeObject(tokenInformation);
			response.Cookies.Append(AuthCookieName, serializedJson, new CookieOptions()
			{
				HttpOnly = true,
				Secure = false, // In production, this should be set to true!
				Expires = DateTime.UtcNow.AddDays(90) // Feel free to tweak expiry
			});
		}

		public static AuthTokenProperties GetCookieFromRequest(HttpRequest request)
		{
			string cookieValue;
			if (!request.Cookies.TryGetValue(AuthCookieName, out cookieValue))
			{
				return null;
			}

			return JsonConvert.DeserializeObject<AuthTokenProperties>(cookieValue);
		}

		public static void ClearCookies(HttpResponse response)
		{
			response.Cookies.Append(AuthCookieName, "", new CookieOptions()
			{
				Expires = DateTime.UtcNow.AddDays(-5) // Expired cookie will be deleted
			});
		}
	}
}
