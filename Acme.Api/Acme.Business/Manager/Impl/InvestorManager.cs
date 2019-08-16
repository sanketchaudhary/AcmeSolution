using Acme.Data.Models;
using Acme.Data.Repository;
using System;

namespace Acme.Business.Manager.Impl
{
    /// <summary>
    /// Manager class to hold Investor related methods
    /// </summary>
    public class InvestorManager : IInvestorManager
    {
        #region PrivateProperties
        private readonly IInvestorRepository _investorRepository;
        #endregion

        // Constructor
        public InvestorManager(IInvestorRepository investorRepository)
        {
            _investorRepository = investorRepository;
        }

        /// <summary>
        /// Business method to add new Investor
        /// </summary>
        /// <param name="investorDetails">Investor details</param>
        public void AddInvestor(InvestorDetails investorDetails)
        {
            try
            {
                // Call method to add Investor
                this._investorRepository.AddInvestor(investorDetails);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
