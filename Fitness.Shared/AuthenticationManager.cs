using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Fitness.Shared
{
	public static class AuthenticationManager
	{
		public static void Init()
		{
			ServicePointManager.ServerCertificateValidationCallback += delegate
			{
				return true;
			};
		}

		public static async Task<bool> Register(string email, string password)
		{
			var parameters = new Dictionary<string, string>
			{
				{ "username", "alex" },
				{ "password", "yeah" }
			};

			var content = new FormUrlEncodedContent(parameters);

			HttpResponseMessage result;

			using (var client = new HttpClient())
			{
				try
				{
					result = await client.PostAsync("https://192.168.1.104:44302/Authentication/Register", content);
				}
				catch (Exception e)
				{
					Console.WriteLine("ERROR: " + e.Message);
					return false;
				}
			}

			if (result.StatusCode != HttpStatusCode.OK)
			{
				Console.WriteLine("ERROR: " + result.StatusCode);
				return false;
			}

			return true;
		}
	}
}