using System.Collections.Generic;

namespace ASPNET_WebApp_MVC.Models
{
    public class InputFile1
    {
        public string Identifier = "123|AbcCode"; /* 123|AbcCode ie. In this format, the identifier column has both a numeric id and an account code, separated by the | character.  Need to parse out the account code and output it. */
        public string Name = "My Account"; /* My Account */
        public int Type = 2; /* 2 ie. The account types are #’s that mean: 1 = Trading | 2 = RRSP | 3 = RESP | 4 = Fund */
        public string Opened = "01-01-2018"; /* 01-01-2018 */
        public string Currency = "CD"; /* CD ie. The CD currency is CAD.  USD would be represented by US */
    }
}