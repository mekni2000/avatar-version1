using AspAdminTemplate.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AspAdminTemplate.Services.ApiServices
{
	public class GenericApiService
	{
		public HttpClient Client { get; }

		public GenericApiService(HttpClient client)
		{
			Client = client;
		}

		public void SetBaseUrl(string baseUrl)
		{
			Client.BaseAddress = new Uri(baseUrl);
		}

		//public async Task<T> ApioGet<T>()
		//{
		//	var response = await Client.GetAsync(
		//		"/repos/aspnet/AspNetCore.Docs/issues?state=open&sort=created&direction=desc");

		//	response.EnsureSuccessStatusCode();

		//	using var responseStream = await response.Content.ReadAsStreamAsync();
		//	return await JsonSerializer.DeserializeAsync
		//		<T>(responseStream);
		//}

		public async Task<T> ApiGet<T>(string endpoint)
		{
			var response = await Client.GetAsync(endpoint);
			string apiResponse = await response.Content.ReadAsStringAsync();
			T data = JsonConvert.DeserializeObject<T>(apiResponse);
			if (response.IsSuccessStatusCode)
			{
				return data;
			}
			else
			{
				throw new HttpListenerException((int)response.StatusCode);
			}
		}

		public async Task<string> ApiDelete(string endpoint)
		{
			var response = await Client.DeleteAsync(endpoint);
			string apiResponse = await response.Content.ReadAsStringAsync();
			return apiResponse;
		}

		public async Task<string> ApiPost<T>(string endpoint, T contentData)
		{
			string json = JsonConvert.SerializeObject(contentData);
			StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

			var response = await Client.PostAsync(endpoint, content);
			string apiResponse = await response.Content.ReadAsStringAsync();
			if (response.IsSuccessStatusCode)
			{
				return apiResponse;
			}
			else
			{
				throw new HttpListenerException((int)response.StatusCode);
			}
		}

		public async Task<string> ApiPut<T>(string endpoint, T contentData)
		{
			string json = JsonConvert.SerializeObject(contentData);
			StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

			var response = await Client.PutAsync(endpoint, content);
			string apiResponse = await response.Content.ReadAsStringAsync();
			if (response.IsSuccessStatusCode)
			{
				return apiResponse;
			}
			else
			{
				throw new HttpListenerException((int)response.StatusCode);
			}
		}

		public async Task<string> ApiPatch(string endpoint)
		{

			var request = new HttpRequestMessage(new HttpMethod("PATCH"), endpoint);

			var response = await Client.SendAsync(request);
			string apiResponse = await response.Content.ReadAsStringAsync();
			if (response.IsSuccessStatusCode)
			{
				return apiResponse;
			}
			else
			{
				throw new HttpListenerException((int)response.StatusCode);
			}
		}

		public async Task<UploadFile> ApiPostImage(string endpoint, IFormFile file)
		{
			//var fileStream = new FileStream(file.FileName, FileMode.Create);
			MemoryStream fileStream = new MemoryStream();
			await file.CopyToAsync(fileStream);
			fileStream.Position = 0;

			HttpContent fileStreamContent = new StreamContent(fileStream);
			fileStreamContent.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("form-data") { Name = "file", FileName = file.FileName };
			fileStreamContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("Image/*");

			var formData = new MultipartFormDataContent();
			formData.Add(fileStreamContent);
			var response = await Client.PostAsync(endpoint, formData);
			
			if (response.IsSuccessStatusCode)
			{
				string apiResponse = await response.Content.ReadAsStringAsync();
				return JsonConvert.DeserializeObject<UploadFile>(apiResponse);
			}
			else
			{
				throw new HttpListenerException((int)response.StatusCode);
			}
		}
	}
}
