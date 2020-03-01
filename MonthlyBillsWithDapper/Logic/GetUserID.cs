using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;


namespace MonthlyBillsWithDapper.Logic
{
    public class GetUserID
    {



        private string userID;


        public  GetUserID()        
        {
  
            var claimsIdentity = User.Identity as ClaimsIdentity;

            var userIdClaim = claimsIdentity.Claims
                .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
            if (userIdClaim != null)
            {
                this.userID = userIdClaim.Value;
            }
            else
            {
                this.userID = "tempuser";
            }

        }
    }
}
