using System.ComponentModel.DataAnnotations;

namespace Acme.Business.Dtos.Investor
{
    public class InvestorDtoForCreate
    {
        [Required]
        [StringLength(120)]
        public string FullName { get; set; }

        [Required]
        public virtual int CountryId { get; set; }

        [Required]
        public virtual string State { get; set; }

        [Required]
        public virtual string Postcode { get; set; }
    }
}
