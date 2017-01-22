using System;

namespace OneNoteApiSample
{
	public static class ControllerRoutes
	{
		public static string HomePage => "/";
		public static string SampleApisPage => "/sampleApis";
		public static string Logout => "/logout";
		public static string ParticularSampleApi(string sampleApiName) => SampleApisPage + "/runApi" + "?name=" + Uri.EscapeDataString(sampleApiName);
	}
}
