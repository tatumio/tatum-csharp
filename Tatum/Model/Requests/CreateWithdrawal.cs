using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Tatum.Model.Requests
{
    public class CreateWithdrawal
    {

        [Required]
        [StringLength(24, MinimumLength = 24)]
        public string senderAccountId { get; set; }

        [Required]
        [StringLength(24, MinimumLength = 1000)]
        public string address { get; set; }

        [Required]       
        public string amount { get; set; }

        [Required]
        public string fee { get; set; }

        [Required]
        public bool complaint { get; set; }

        [Required]
        public string paymentId { get; set; }

        [Required]
        public string senderNote { get; set; }

        [Required]
        public string[] multipleAmounts { get; set; }

        [Required]
        public string attr { get; set; }

    }
}