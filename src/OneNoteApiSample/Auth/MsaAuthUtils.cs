using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace OneNoteApiSample.Auth
{
	public class MsaAuthUtils
	{
		public static readonly MsaAuthUtils Instance = new MsaAuthUtils(Config.MsaAppId, Config.MsaAppSecret,
			Config.MsaRequiredScopes, Config.MsaRedirectUri);

		// Collateral used to refresh access token (only applicable when the app uses the wl.offline_access wl.signin scopes) 
		private const string MsaTokenRefreshUrl = "https://login.live.com/oauth20_token.srf";
		private const string TokenRefreshContentType = "application/x-www-form-urlencoded";

		private string _appId;
		private string _appSecret;
		private string _redirectUrl;
		private IEnumerable<string> _scopes;

		public MsaAuthUtils(string appId, string appSecret, IEnumerable<string> scopes, string redirectUrl)
		{
			_appId = appId;
			_appSecret = appSecret;
			_scopes = scopes;
			_redirectUrl = redirectUrl;
		}

		private async Task<MsaGetTokenResponse> ExchangeCodeForAccessTokenPrivate(string code)
		{
			try
			{
				using (HttpClient client = new HttpClient())
				{
					var postFormParameters = new List<KeyValuePair<string, string>>()
					{
						new KeyValuePair<string, string>("client_id", _appId),
						new KeyValuePair<string, string>("redirect_uri", _redirectUrl),
						new KeyValuePair<string, string>("code", code),
						new KeyValuePair<string, string>("grant_type", "authorization_code"),
					};

					if (_appSecret != null)
					{
						// Secret isn't needed for client apps
						postFormParameters.Add(new KeyValuePair<string, string>("client_secret", _appSecret));
					}

					var formContent = new FormUrlEncodedContent(postFormParameters);
					client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", TokenRefreshContentType);

					HttpResponseMessage response = await client.PostAsync(MsaTokenRefreshUrl, formContent);
					string responseString = await response.Content.ReadAsStringAsync();
					MsaGetTokenResponse msa = JsonConvert.DeserializeObject<MsaGetTokenResponse>(responseString);
					return msa;
				}
			}
			catch (Exception ex)
			{
				// Log this??
				throw;
			}
		}

		public string BuildUrl()
		{
			string completeRedirectUrl =
				WebUtility.UrlEncode(_redirectUrl);

			string authUrl = "https://login.live.com/oauth20_authorize.srf?client_id=" + _appId + "&scope=" +
				string.Join(" ", _scopes) + "&response_type=code&redirect_uri=" + completeRedirectUrl;

			return authUrl;
		}

		public async Task<AuthTokenProperties> ExchangeCodeForAccessToken(string code)
		{
			MsaGetTokenResponse msaData = await ExchangeCodeForAccessTokenPrivate(code);
			return TransformMsaTokenResponseIntoAuthProperties(msaData);
		}

		private AuthTokenProperties TransformMsaTokenResponseIntoAuthProperties(MsaGetTokenResponse msaData)
		{
			int expiresIn = -1;
			int.TryParse(msaData.expires_in, out expiresIn);
			return new AuthTokenProperties(msaData.access_token, expiresIn, msaData.refresh_token, msaData.user_id);
		}

		public async Task<AuthTokenProperties> ExchangeRefreshTokenForAuthInfo(string refreshToken)
		{
			try
			{
				using (HttpClient client = new HttpClient())
				{
					var postFormParameters = new List<KeyValuePair<string, string>>()
					{
						new KeyValuePair<string, string>("client_id", _appId),
						new KeyValuePair<string, string>("redirect_uri", _redirectUrl),
						new KeyValuePair<string, string>("refresh_token", refreshToken),
						new KeyValuePair<string, string>("grant_type", "refresh_token"),
					};

					if (_appSecret != null)
					{
						postFormParameters.Add(new KeyValuePair<string, string>("client_secret", _appSecret));
					}

					var formContent = new FormUrlEncodedContent(postFormParameters);

					client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", TokenRefreshContentType);

					var response = await client.PostAsync(MsaTokenRefreshUrl, formContent);
					string responseString = await response.Content.ReadAsStringAsync();
					MsaGetTokenResponse msa = JsonConvert.DeserializeObject<MsaGetTokenResponse>(responseString);
					return TransformMsaTokenResponseIntoAuthProperties(msa);
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine("Failed to refresh token! " + ex);
				throw;
			}
		}
	}
}
