using System.Collections.Generic;
using System.Linq;
using WebApi.Entities;
using WebApi.Helpers;

namespace WebApi.Services
{
    public interface IMstBranchService
    {
        IEnumerable<MstBranch> GetAll();
        MstBranch GetByCd(string cd);
        IEnumerable<MstBranch> GetByName(string name);
    }

    public class MstBranchService : IMstBranchService
    {
        private DataContext _context;

        public MstBranchService(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<MstBranch> GetAll()
        {
            return _context.MstBranches;
        }

        public MstBranch GetByCd(string cd)
        {
            return _context.MstBranches.ToList().Where(x => x.Cd == cd).SingleOrDefault();
        }
        public IEnumerable<MstBranch> GetByName(string name)
        {
            return _context.MstBranches.ToList().Where(x => x.Name.Contains(name));
        }
    }
}