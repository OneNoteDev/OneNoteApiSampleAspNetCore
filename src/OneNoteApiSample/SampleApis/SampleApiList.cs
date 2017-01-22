using System.Collections.Generic;

namespace OneNoteApiSample.SampleApis
{
	public static class SampleApiList
	{
		private const string OneNoteApiBaseUrl = "https://www.onenote.com/api/beta/me/notes";

		public static List<SampleApi> SampleApis => new List<SampleApi>()
		{
			new SampleApi("GET ~/pages", "Get the list of the user's most recent pages", "GET", OneNoteApiBaseUrl + "/pages", null, null),
			new SampleApi("GET ~/notebooks", "Get the list of the user's notebooks.", "GET", OneNoteApiBaseUrl + "/notebooks", null, null),
			new SampleApi("GET ~/sections", "Get the list of the user's sections.", "GET", OneNoteApiBaseUrl + "/sections", null, null),
			new SampleApi("GET ~/sectionGroups", "Get the list of the user's sectionGroups.", "GET", OneNoteApiBaseUrl + "/sectionGroups", null, null),
			new SampleApi("POST ~/pages", "Create a page in the default section.", "POST", OneNoteApiBaseUrl + "/pages", "<html><body><p>This is a page as HTML!</p></body></html>", "text/html"),
		};

		public static SampleApi GetSampleApiByName(string name)
		{
			return SampleApis.Find(s => s.Name == name);
		}
	}
}
