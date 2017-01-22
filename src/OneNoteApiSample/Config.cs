using System.Collections.Generic;

namespace OneNoteApiSample
{
	public static class Config
	{
		// TODO: Replace all of these with your own
		// Note: Redirect URIs should be HTTPS, but it is easier to deploy/play with HTTP
		public static string MsaRedirectUri => "http://onenoteapisamplenetcore.azurewebsites.net/msaoauthcallback";
		public static string MsaAppId => "000000004C1BCD88";
		public static string MsaAppSecret => "rkDgiOLPsDbsVSq3wxearjb";

		// TODO: Your app might require a different list of scopes.
		// See https://msdn.microsoft.com/en-us/library/office/dn807159.aspx and https://msdn.microsoft.com/en-us/library/hh243646.aspx#wlbasic
		public static List<string> MsaRequiredScopes => new List<string>()
		{
			"office.onenote_update",
			"wl.basic",
			"wl.offline_access",
			"wl.signin"
		};

		// TODO: This sample does not support O365 authentication
	}
}
