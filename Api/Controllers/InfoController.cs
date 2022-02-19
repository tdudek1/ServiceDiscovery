using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Api.Controllers
{

	[ApiController]
	[Route("/")]
	public class InfoController : ControllerBase
	{

		[HttpGet]
		[Route("")]
		public JsonResult Get()
		{
			var connectionFeature = this.HttpContext.Features.Get<IHttpConnectionFeature>();

			return new JsonResult(
				new
				{
					Hostname  = Dns.GetHostName(),
					LocalIp = connectionFeature?.LocalIpAddress?.ToString(),
					LocalPort = connectionFeature?.LocalPort,
					RemoteIp = connectionFeature?.RemoteIpAddress?.ToString(),
					RemotePort = connectionFeature?.RemotePort,
					Url= UriHelper.GetDisplayUrl(Request),
					RequestId = HttpContext.TraceIdentifier,
					Environment = Environment.GetEnvironmentVariables()
				});
		}
	}
}
