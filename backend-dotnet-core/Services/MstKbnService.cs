using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Entities;
using WebApi.Helpers;

namespace WebApi.Services
{
    public interface IMstKbnService
    {
        IEnumerable<MstKbn> GetByKbn(string kbn);
        MstKbn GetByKbnAndCd(string kbn, string cd);
    }

    public class MstKbnService : IMstKbnService
    {
        private DataContext _context;

        public MstKbnService(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<MstKbn> GetByKbn(string kbn)
        {
            return _context.MstKbns.ToList().Where(x => x.Kbn == kbn).OrderBy(x => x.Cd);
        }

        public MstKbn GetByKbnAndCd(string kbn, string cd)
        {
            return _context.MstKbns
            .Where(x => x.Kbn == kbn)
            .Where(x => x.Cd == cd)
            .OrderBy(x => x.Cd).SingleOrDefault();
        }
    }
}