using System.Collections.Generic;

namespace ASPNET_WebApp_MVC.Models
{
    public class InputFile2
    {
        public string Name = "My Account"; /* My Account */
        public int Type = 2; /* 2 ie. The account types are #’s that mean: 1 = Trading | 2 = RRSP | 3 = RESP | 4 = Fund */
        public string Currency = "C"; /* C ie. The Currency column has C for CAD and U for USD. */
        public string CustodianCode = "567"; /* "unspecified" ie. The Custodian Code is to become the Account Code in the standard output. */

    }
}