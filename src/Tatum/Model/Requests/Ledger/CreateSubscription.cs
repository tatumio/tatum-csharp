using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Tatum.Model.Requests
{
    public abstract class CreateSubscription : IValidatableObject
    {
        [Required]
        [JsonPropertyName("type")]
        public string Type { get; protected set; }

        public abstract IEnumerable<ValidationResult> Validate(ValidationContext validationContext);
    }

    public abstract class CreateSubscriptionAttribute
    {
    }

    public class CreateSubscriptionBalance : CreateSubscription
    {
        public CreateSubscriptionBalance()
        {
            Type = "ACCOUNT_BALANCE_LIMIT";
        }

        [Required]
        [JsonPropertyName("attr")]
        public BalanceAttribute Attribute { get; set; }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> results = new List<ValidationResult>();
            if (Attribute != null)
            {
                var customerContext = new ValidationContext(Attribute);
                Validator.TryValidateObject(Attribute, customerContext, results, validateAllProperties: true);
            }

            if (results.Count == 0)
            {
                results.Add(ValidationResult.Success);
            }

            return results;
        }
    }

    public class BalanceAttribute : CreateSubscriptionAttribute
    {
        [Required]
        [StringLength(38, MinimumLength = 1)]
        [RegularExpression(@"^[+]?((\d+(\.\d*)?)|(\.\d+))$")]
        [JsonPropertyName("limit")]
        public string Limit { get; set; }

        [Required]
        [JsonPropertyName("typeOfBalance")]
        public string TypeOfBalance { get; set; }
    }

    public class CreateSubscriptionInterval : CreateSubscription
    {
        public CreateSubscriptionInterval()
        {
            Type = "TRANSACTION_HISTORY_REPORT";
        }

        [Required]
        [JsonPropertyName("attr")]
        public IntervalAttribute Attribute { get; set; }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> results = new List<ValidationResult>();
            if (Attribute != null)
            {
                var customerContext = new ValidationContext(Attribute);
                Validator.TryValidateObject(Attribute, customerContext, results, validateAllProperties: true);
            }

            if (results.Count == 0)
            {
                results.Add(ValidationResult.Success);
            }

            return results;
        }
    }

    public class IntervalAttribute : CreateSubscriptionAttribute
    {
        [Required]
        [Range(1, 720)]
        [JsonPropertyName("interval")]
        public int Interval { get; set; }
    }

    public class CreateSubscriptionOffchain : CreateSubscription
    {
        public CreateSubscriptionOffchain()
        {
            Type = "OFFCHAIN_WITHDRAWAL";
        }

        [Required]
        [JsonPropertyName("attr")]
        public OffchainAttribute Attribute { get; set; }
        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> results = new List<ValidationResult>();
            if (Attribute != null)
            {
                var customerContext = new ValidationContext(Attribute);
                Validator.TryValidateObject(Attribute, customerContext, results, validateAllProperties: true);
            }

            if (results.Count == 0)
            {
                results.Add(ValidationResult.Success);
            }

            return results;
        }

    }

    public class OffchainAttribute : CreateSubscriptionAttribute
    {
        [Required]
        [StringLength(30, MinimumLength = 1)]
        [JsonPropertyName("currency")]
        public string Currency { get; set; }
    }

    public class CreateSubscriptionComplete : CreateSubscription
    {
        public CreateSubscriptionComplete()
        {
            Type = "COMPLETE_BLOCKCHAIN_TRANSACTION";
        }

        [Required]
        [JsonPropertyName("attr")]
        public CompleteAttribute Attribute { get; set; }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> results = new List<ValidationResult>();
            if (Attribute != null)
            {
                var customerContext = new ValidationContext(Attribute);
                Validator.TryValidateObject(Attribute, customerContext, results, validateAllProperties: true);
            }

            if (results.Count == 0)
            {
                results.Add(ValidationResult.Success);
            }

            return results;
        }
    }

    public class CompleteAttribute : CreateSubscriptionAttribute
    {
        [Required]
        [StringLength(30, MinimumLength = 1)]
        [JsonPropertyName("currency")]
        public string Currency { get; set; }
    }

    public class CreateSubscriptionIncoming : CreateSubscription
    {
        public CreateSubscriptionIncoming()
        {
            Type = "ACCOUNT_INCOMING_BLOCKCHAIN_TRANSACTION";
        }

        [Required]
        [JsonPropertyName("attr")]
        public IncomingAttribute Attribute { get; set; }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> results = new List<ValidationResult>();
            if (Attribute != null)
            {
                var customerContext = new ValidationContext(Attribute);
                Validator.TryValidateObject(Attribute, customerContext, results, validateAllProperties: true);
            }

            if (results.Count == 0)
            {
                results.Add(ValidationResult.Success);
            }

            return results;
        }    
    }

    public class IncomingAttribute : CreateSubscriptionAttribute
    {
        [Required]
        [StringLength(24, MinimumLength = 24)]
        [JsonPropertyName("id")]
        public string AccountId { get; set; }
        
        [Required]
        [StringLength(500)]
        [JsonPropertyName("url")]
        public int Url { get; set; }
    }
}
