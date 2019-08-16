using System;
using System.Collections.Generic;

namespace Acme.Data.Models
{
    public partial class Postcodes
    {
        public int Id { get; set; }
        public string Pcode { get; set; }
        public string Locality { get; set; }
        public string State { get; set; }
        public string Comments { get; set; }
        public string DeliveryOffice { get; set; }
        public string PreSortIndicator { get; set; }
        public string ParcelZone { get; set; }
        public string Bspnumber { get; set; }
        public string Bspname { get; set; }
        public string Category { get; set; }
    }
}
