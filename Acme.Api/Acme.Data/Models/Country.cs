using System;
using System.Collections.Generic;

namespace Acme.Data.Models
{
    public partial class Country
    {
        public Country()
        {
            InvestorDetails = new HashSet<InvestorDetails>();
        }

        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public string CountryCode { get; set; }

        public ICollection<InvestorDetails> InvestorDetails { get; set; }
    }
}
