using System.Security.Claims;
using System.Security.Principal;

namespace app.DataLayer.Context
{
    public static class ClaimExtended
    {
        public const string _userId = "userId";
        public const string _storeId = "storeId";
        public static string UserId(this IPrincipal user)
        {
            var claim = ((ClaimsIdentity)user.Identity).FindFirst(_userId);
            return claim == null ? null : claim.Value;
        }
        public static string StoreId(this IPrincipal user)
        {
            var claim = ((ClaimsIdentity)user.Identity).FindFirst(_storeId);
            return claim == null ? null : claim.Value;
        }

    }
}
