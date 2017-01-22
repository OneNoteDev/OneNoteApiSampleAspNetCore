namespace OneNoteApiSample.SampleApis
{
	/// <summary>
	/// Represents an API to call (includes description and data to call the API
	/// </summary>
	public class SampleApi
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public string HttpMethod { get; set; }
		public string HttpPath { get; set; }
		public string HttpBody { get; set; }
		public string HttpContentHeader { get; set; }

		public SampleApi(string name, string description, string httpMethod, string httpPath, string httpBody, string httpContentHeader)
		{
			Name = name;
			Description = description;
			HttpMethod = httpMethod;
			HttpPath = httpPath;
			HttpBody = httpBody;
			HttpContentHeader = httpContentHeader;
		}
	}
}
