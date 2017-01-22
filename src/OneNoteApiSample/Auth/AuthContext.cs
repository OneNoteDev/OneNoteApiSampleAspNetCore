using Microsoft.AspNetCore.Http;

namespace OneNoteApiSample.Auth
{
	/// <summary>
	/// Manages the signed in state
	/// </summary>
	public static class AuthContext
	{
		private const string AuthContextKey = "OneNoteApiSampleAuthContextKey";

		public static bool IsSignedIn(HttpContext context)
		{
			object value;
			if (!context.Items.TryGetValue(AuthContextKey, out value))
			{
				return false;
			}

			return (value as AuthTokenProperties) != null;
		}

		public static void SetContext(HttpContext context, AuthTokenProperties tokenProperties)
		{
			context.Items[AuthContextKey] = tokenProperties;
		}

		public static AuthTokenProperties GetContext(HttpContext context)
		{
			return context.Items[AuthContextKey] as AuthTokenProperties;
		}
	}
}
