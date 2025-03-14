using System.Security.Claims;
using MultiShop.WebUI.Services.Concrete;

namespace MultiShop.WebUI.Services
{
    public class LoginService : ILoginService
	{
		private readonly IHttpContextAccessor _contextAccessor;

		public LoginService(IHttpContextAccessor contextAccessor)
		{
			_contextAccessor = contextAccessor;
		}

		public string GetUserId =>_contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
	}
}
