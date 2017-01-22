using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OneNoteApiSample.Auth
{
	public class AuthTokenProperties
	{
		/// <summary>
		/// For serialization
		/// </summary>
		public AuthTokenProperties()
		{

		}

		public AuthTokenProperties(string accessToken, int expiresIn, string refreshToken, string userId)
			: this(accessToken, expiresIn, refreshToken, userId, DateTime.UtcNow)
		{

		}

		/// <summary>
		/// For UT
		/// </summary>
		public AuthTokenProperties(string accessToken, int expiresIn, string refreshToken, string userId, DateTime now)
		{
			AccessToken = accessToken;
			Expiry = now.AddSeconds(expiresIn - 100); // Grace period
			RefreshToken = refreshToken;
			UserId = userId;
		}

		public string RefreshToken { get; set; }
		public string AccessToken { get; set; }
		public DateTime Expiry { get; set; }

		public string UserId { get; set; }
	}
}
