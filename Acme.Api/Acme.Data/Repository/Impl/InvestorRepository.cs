using Acme.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Acme.Data.Repository.Impl
{
    public class InvestorRepository : BaseRepository, IInvestorRepository
    {
        #region PrivateProperties
        private readonly DbSet<InvestorDetails> investorEntity;
        #endregion

        /// <summary>
        /// Investor repository constructor
        /// </summary>
        /// <param name="context">Acme DB context</param>
        public InvestorRepository(AcmeContext context): base(context)
        {
            // Set Investor Entity
            investorEntity = context.Set<InvestorDetails>();
        }

        /// <summary>
        /// Repository method to add new Investor
        /// </summary>
        /// <param name="investorDetails"></param>
        public void AddInvestor(InvestorDetails investorDetails)
        {
            // Add Investor
            this.investorEntity.Add(investorDetails);

            // Save changes to DB
            this._context.SaveChanges();
        }
    }
}
