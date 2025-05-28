using Microsoft.AspNetCore.Http;


namespace EV.Common.Utilities
{
	public class CookiesManager
	{

		public static void Add(HttpContext context, string key, string value, int days)
		{
			context.Response.Cookies.Append(key, value, GetCookieOptions(context, days));
		}

		public static void Remove(HttpContext context, string key)
		{
			context.Response.Cookies.Delete(key);
		}

		public static bool Contains(HttpContext context, string key)
		{
			return context.Request.Cookies.ContainsKey(key);
		}

		public static string GetValue(HttpContext context, string key)
		{
			string value;
			context.Request.Cookies.TryGetValue(key, out value);

			return value;
		}

		private static CookieOptions GetCookieOptions(HttpContext context, int days)
		{
			return new CookieOptions()
			{
				HttpOnly = true,
				Secure = context.Request.IsHttps,
				Path = context.Request.PathBase.HasValue ? context.Request.PathBase.ToString() : "/",
				Expires = DateTime.Now.AddDays(days)
			};
		}
	}
}
