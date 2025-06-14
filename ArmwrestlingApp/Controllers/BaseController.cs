using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace ArmwrestlingApp.Controllers
{
    public class BaseController : Controller
    {

        protected bool IsGuidValid(string? id, ref Guid parsedGuid)
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

        protected string? GetCurrentUserId() // nullable che moje dane vurne stoinost
        {
            //return User.FindFirstValue("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier");
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
            // moje i ot usermanagera ama se rovi v bazata po-dobre ot cookieto 

        }

        protected bool IsUserAuthenticated()
        {

            if (User?.Identity?.IsAuthenticated ?? false)
            {
                return true;
            }

            return false;
        }
    }
}
