using System.Security.Claims;
using ArmwrestlingApp.Models;
using ArmwrestlingApp.Services.Data.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace ArmwrestlingApp.Services.Data
{
    public class BaseService: IBaseService
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly UserManager<ApplicationUser> userManager;

        public BaseService(IHttpContextAccessor _httpContextAccessor, UserManager<ApplicationUser> _userManager)
        {
             this.httpContextAccessor = _httpContextAccessor;  
            this.userManager = _userManager;
        }
        public bool IsGuidValid(string? id, ref Guid parsedGuid)
        {
            // Non-existing parameter in the URL
            if (String.IsNullOrWhiteSpace(id))
            {
                return false;
            }

            // Invalid parameter in the URL
            bool isGuidValid = Guid.TryParse(id, out parsedGuid);
            if (!isGuidValid)
            {
                return false;
            }

            return true;
        }

        public async Task<Guid> GetCurrentUserIdAsync()
        {
            var userPrincipal = httpContextAccessor.HttpContext?.User;

            if (userPrincipal == null || !userPrincipal.Identity?.IsAuthenticated == true)
            {
                return Guid.Empty;
            }
                
            //var user = await userManager.GetUserAsync(userPrincipal);

            var userId = userPrincipal?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userId == null)
            {
                return Guid.Empty;
            }

            Guid userGuid = Guid.Empty;

            Guid.TryParse(userId.ToString(), out userGuid);
            if (userGuid == Guid.Empty)
            {
                return Guid.Empty;
            }

            return userGuid;
        }
    }
}
