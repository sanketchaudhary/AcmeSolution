using Acme.Data.Models;
using System.Collections.Generic;

namespace Acme.Data.Repository
{
    public interface IAddressRepository
    {
        /// <summary>
        /// Repository method to get Country list
        /// </summary>
        /// <returns>Country list</returns>
        IEnumerable<Country> GetCountryList();

        /// <summary>
        /// Repository method to get Postcode list
        /// </summary>
        /// <returns>Postcode list</returns>
        IEnumerable<Postcodes> GetPostcodes();
    }
}
