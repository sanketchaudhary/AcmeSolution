using Acme.Business.Dtos.Investor;
using Acme.Business.Manager;
using Acme.Data.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Acme.Api.Controllers
{
    /// <summary>
    /// Investor Controoler for Investore related api methods
    /// </summary>
    [Route("api/investor")]
    [ApiController]
    public class InvestorController : ControllerBase
    {
        #region PrivateVariables
        private readonly IMapper _mapper;
        private readonly IInvestorManager _investorManager;
        #endregion

        /// <summary>
        /// Investor Constructor
        /// </summary>
        /// <param name="mapper">Automapper dependency</param>
        /// <param name="investorManager">Investor Manager dependency</param>
        public InvestorController(IMapper mapper, IInvestorManager investorManager)
        {
            _mapper = mapper;
            _investorManager = investorManager;
        }

        /// <summary>
        /// Api method to get Investor details
        /// </summary>
        /// <returns></returns>
        [HttpPost("get")]
        public IActionResult Get()
        {
            return Ok();
        }

        /// <summary>
        /// Api method to create new Investor record
        /// </summary>
        /// <param name="investorDetailsDto">Investor details</param>
        /// <returns></returns>
        [HttpPost("create")]
        public IActionResult Create([FromBody]InvestorDtoForCreate investorDetailsDto)
        {
            try
            {
                // Check if Investor details are valid
                if (investorDetailsDto != null && ModelState.IsValid)
                {
                    // Convert investor dto to DB model
                    var investorModel = _mapper.Map<InvestorDetails>(investorDetailsDto);

                    // Call Business method to add Investor
                    _investorManager.AddInvestor(investorModel);

                    return Ok(true);
                }
                else
                {
                    return BadRequest("Investor details are not valid.");
                }
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}