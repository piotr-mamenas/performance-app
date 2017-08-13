using System.ComponentModel.DataAnnotations;

namespace Core.Domain.NonPersistent
{
    /// <summary>
    /// A bank identifier code (BIC) is a unique identifier for a specific financial institution. 
    ///A BIC is composed of a 4-character bank code, 
    ///                     a 2-character country code, 
    ///                     a 2-character location code 
    ///                and an optional 3-character branch code.
    /// </summary>
    public class Bic
    {
        [Required]
        [MaxLength(4)]
        public string BankCode { get; set; }

        [Required]
        [MaxLength(2)]
        public string CountryCode { get; set; }

        [Required]
        [MaxLength(2)]
        public string LocationCode { get; set; }
        
        [MaxLength(3)]
        public string BranchCode { get; set; }
    }
}
