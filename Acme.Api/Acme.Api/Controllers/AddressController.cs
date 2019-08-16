using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Acme.Business.Dtos.Address;
using Acme.Business.Manager;
using System;

namespace Acme.Api.Controllers
{
    [Route("api/address")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        #region PrivateVariables
        private readonly IMapper _mapper;
        private readonly IAddressManager _addressManager;
        #endregion

        /// <summary>
        /// Address Constructor
        /// </summary>
        /// <param name="mapper">Automapper dependency</param>
        /// <param name="addressManager">Address Manager dependency</param>
        public AddressController(IMapper mapper, IAddressManager addressManager)
        {
            _mapper = mapper;
            _addressManager = addressManager;
        }

        /// <summary>
        /// Api endpoint to get Country list
        /// </summary>
        /// <returns>Country list</returns>
        [HttpGet("countryList", Name = "GetCountryList")]
        public IActionResult GetCountryList()
        {
            try
            {
                // Call business method to retrieve Country list
                var countryList = this._addressManager.GetCountryList();

                // Map country list to Dto
                var countryListDto = _mapper.Map<IEnumerable<CountryDto>>(countryList);

                // Return country list
                return Ok(countryListDto);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Api endpoint to get States
        /// </summary>
        /// <returns>States</returns>
        [HttpGet("states", Name = "GetStates")]
        public IActionResult GetStates()
        {
            try
            {
                // Call business method to retrieve Postcodes
                var states = this._addressManager.GetStates();

                // Return States
                return Ok(states);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Api endpoint to check if State and Postcode combination is valid
        /// </summary>
        /// <returns>True if valid else false</returns>
        [HttpGet("isStateAndPostcodeValid", Name = "IsStateAndPostcodeValid")]
        public IActionResult CheckIfStateAndPostcodeIsValid(string state, string postcode)
        {
            try
            {
                if(!string.IsNullOrEmpty(state) && !string.IsNullOrEmpty(postcode))
                {
                    // Call business method to check if state and postcode combination is valid
                    var isValid = this._addressManager.CheckIfStateAndPostcodeIsValid(state, postcode);

                    // Return
                    return Ok(isValid);
                } else
                {
                    return BadRequest("State or Postcode is null or empty");
                }
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}