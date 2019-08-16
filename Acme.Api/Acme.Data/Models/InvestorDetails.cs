using System;
using System.Collections.Generic;

namespace Acme.Data.Models
{
    public partial class InvestorDetails
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int CountryId { get; set; }
        public string State { get; set; }
        public string Postcode { get; set; }

        public Country Country { get; set; }
    }
}
