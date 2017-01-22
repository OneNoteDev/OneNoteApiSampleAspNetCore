using System.Collections.Generic;

using FluentAssertions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using OneNoteApiSample.Auth;

namespace OneNoteApiSampleUnitTests
{
	[TestClass]
	public class MsaAuthUtilsUnitTests
	{
		[TestMethod]
		public void AuthUrlGeneration_GeneratedCorrectly()
		{
			var authUtils = new MsaAuthUtils("MyAppId", "MyAppSecret", new List<string>() {"Scope1", "Scope2"},
				"https://www.microsoft.com");

			var authUrl = authUtils.BuildUrl();

			authUrl.Should().Be("https://login.live.com/oauth20_authorize.srf?client_id=MyAppId&scope=Scope1 Scope2&response_type=code&redirect_uri=https%3A%2F%2Fwww.microsoft.com");
		}
	}
}
