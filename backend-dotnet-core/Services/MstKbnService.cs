using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Entities;
using WebApi.Helpers;

namespace WebApi.Services
{
    public interface IMstKbnService
    {
        // IEnumerable<MstKbn> GetAll();
        // // IEnumerable<MstProduct> GetByName(string name);
        // MstKbn GetByCd(string cd);
        IEnumerable<MstKbn> GetByKbn(string kbn);
    }

    public class MstKbnService : IMstKbnService
    {
        private DataContext _context;

        public MstKbnService(DataContext context)
        {
            _context = context;
        }

        // public IEnumerable<MstKbn> GetAll()
        // {
        //     return _context.MstKbns;
        // }

        public IEnumerable<MstKbn> GetByKbn(string kbn)
        {
            return _context.MstKbns.ToList().Where(x => x.Kbn == kbn).OrderBy(x => x.Cd);
        }

        // public MstKbn GetByCd(string cd)
        // {
        //     return _context.MstKbns.ToList().Where(x => x.Cd == cd).SingleOrDefault();
        // }
    }
}