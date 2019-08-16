using Acme.Data.Models;
using System.Collections.Generic;

namespace Acme.Business.Manager
{
    public interface IAddressManager
    {
        /// <summary>
        /// Manager method to retrieve Country list
        /// </summary>
        /// <returns>Country list</returns>
        IEnumerable<Country> GetCountryList();

        /// <summary>
        /// Manager method to retrieve Postcodes
        /// </summary>
        /// <returns>Postcodes</returns>
        IEnumerable<Postcodes> GetPostcodes();

        /// <summary>
        /// Manager method to retrieve States
        /// </summary>
        /// <returns>States List</returns>
        IEnumerable<string> GetStates();

        /// <summary>
        /// Manager method to check if State and Postcode is valid
        /// </summary>
        /// <returns>True if valid else false</returns>
        bool CheckIfStateAndPostcodeIsValid(string state, string postcode);
    }
}
