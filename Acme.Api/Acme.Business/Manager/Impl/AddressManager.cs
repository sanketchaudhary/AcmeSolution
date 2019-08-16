using System;
using System.Collections.Generic;
using System.Linq;
using Acme.Data.Models;
using Acme.Data.Repository;

namespace Acme.Business.Manager.Impl
{
    /// <summary>
    /// Manager class to hold Address related methods
    /// </summary>
    public class AddressManager : IAddressManager
    {
        // Private properties
        private readonly IAddressRepository _addressRepository;

        // Constructor
        public AddressManager(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        /// <summary>
        /// Manager method to retrieve Country list
        /// </summary>
        /// <returns>Country list</returns>
        public IEnumerable<Country> GetCountryList()
        {
            try
            {
                // Get Country list
                return this._addressRepository.GetCountryList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Manager method to retrieve Postcodes
        /// </summary>
        /// <returns>Postcodes</returns>
        public IEnumerable<Postcodes> GetPostcodes()
        {
            try
            {
                // Get Post codes
                return this._addressRepository.GetPostcodes();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Manager method to retrieve States
        /// </summary>
        /// <returns>States List</returns>
        public IEnumerable<string> GetStates()
        {
            try
            {
                IEnumerable<string> states = new List<string>();

                // Get Postcodes
                var postcodes = this._addressRepository.GetPostcodes().ToList();

                // Check if Postcodes exist
                if (postcodes != null)
                {
                    states = postcodes.Select(p => p.State).Distinct();
                }
                return states;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Manager method to check if State and Postcode is valid
        /// </summary>
        /// <returns>True if valid else false</returns>
        public bool CheckIfStateAndPostcodeIsValid(string state, string postcode)
        {
            try
            {
                bool isValid = false;

                // Get Postcodes
                var postcodes = this._addressRepository.GetPostcodes().ToList();

                // If Postcode records are retrieved check if State and postcode combination is valid
                if (postcodes != null)
                {
                    isValid = postcodes.Where(p => p.State == state && p.Pcode == postcode).Count() > 0;
                }
                return isValid;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
