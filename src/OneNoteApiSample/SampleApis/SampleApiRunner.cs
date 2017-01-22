using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;

using OneNoteApiSample.Auth;

namespace OneNoteApiSample.SampleApis
{
	public static class SampleApiRunner
	{
		public static async Task<SampleApiResult> ExecuteApiCall(HttpContext httpContext, SampleApi sampleApi)
		{
			var client = new HttpClient();
			var request = new HttpRequestMessage(new HttpMethod(sampleApi.HttpMethod), sampleApi.HttpPath);
			request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", AuthContext.GetContext(httpContext).AccessToken);
			if (sampleApi.HttpBody != null)
			{
				request.Content = new StringContent(sampleApi.HttpBody);
				request.Content.Headers.ContentType = new MediaTypeHeaderValue(sampleApi.HttpContentHeader);
			}
			var response = await client.SendAsync(request);
			string responseDescription = response.ToString();
			string requestDescription = request.ToString();

			string responseBody = await response.Content.ReadAsStringAsync();

			responseDescription += Environment.NewLine + Environment.NewLine + responseBody;

			return new SampleApiResult(sampleApi, responseDescription, requestDescription);
		}
	}
}
