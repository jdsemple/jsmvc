using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASPNET_WebApp_MVC.Models
{
    public class TargetFile
    {
        public int Id { get; set; } /* optional: received only in File #1 */
        public string? AccountCode { get; set; }
        public AccountType Type { get; set; }

        public enum AccountType
        {
            Trading,
            RRSP,
            RESP,
            Fund
        }

        public string? Name { get; set; }

        [Display(Name = "Opened")]
        [DataType(DataType.Date)]
        public DateTime OpenedDate { get; set; } /* optional: received only in File #1 */

        public CurrencyCode Currency { get; set; }
        public enum CurrencyCode
        {
            CAD,
            USD
        }

        /*[Column(TypeName = "decimal(18, 2)")]
        public decimal Balance { get; set; }*/
    }
}