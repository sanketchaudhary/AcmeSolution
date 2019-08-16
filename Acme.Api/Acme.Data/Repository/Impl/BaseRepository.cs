using Acme.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Acme.Data.Repository.Impl
{
    public class BaseRepository: IRepository
    {
        public readonly AcmeContext _context;

        /// <summary>
        /// Address repository constructor
        /// </summary>
        /// <param name="context">Acme DB context</param>
        public BaseRepository(AcmeContext context)
        {
            _context = context;
        }
    }
}
