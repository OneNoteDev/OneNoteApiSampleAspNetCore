using System.Collections.Generic;

namespace OneNoteApiSample.SampleApis
{
	/// <summary>
	/// Represents an API to call (includes description and data to call the API
	/// </summary>
	public class SampleApiResult
	{
		public SampleApi SampleApi { get; set; }
		public string SerializedResponse { get; set; }
		public string SerializedRequest { get; set; }

		public SampleApiResult(SampleApi sampleApi, string serializedResponse, string serializedRequest)
		{
			SampleApi = sampleApi;
			SerializedResponse = serializedResponse;
			SerializedRequest = serializedRequest;
		}
	}
}
