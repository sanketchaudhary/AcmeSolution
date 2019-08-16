using Acme.Data.Models;

namespace Acme.Business.Manager
{
    public interface IInvestorManager
    {
        /// <summary>
        /// Business method to add new Investor
        /// </summary>
        /// <param name="investorDetails">Investor details</param>
        void AddInvestor(InvestorDetails investorDetails);
    }
}
