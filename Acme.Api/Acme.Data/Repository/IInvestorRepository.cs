
using Acme.Data.Models;

namespace Acme.Data.Repository
{
    public interface IInvestorRepository
    {
        void AddInvestor(InvestorDetails investorDetails);
    }
}
