using CDASLiteEntityLayer.IdentityModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CDASLiteUI.ClaimProvider
{
    public class ClaimProvider : IClaimsTransformation
    {
        private UserManager<AppUser> userManager { get; set; }
        public ClaimProvider(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }
        public async Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
            if (principal != null && principal.Identity.IsAuthenticated)
            {
                ClaimsIdentity identity = principal.Identity as ClaimsIdentity;
                AppUser user = await userManager.FindByNameAsync(identity.Name);
                if (user != null)
                {
                    if (principal.HasClaim(c => c.Type == "gender"))
                    {
                        //if there is no claim such as gender, add one.
                        Claim genderClaim = new Claim("gender", user.Gender.ToString(), ClaimValueTypes.Integer32, "Internal");
                        identity.AddClaim(genderClaim);
                    }
                }
            }
            return principal;
        }
    }
}
