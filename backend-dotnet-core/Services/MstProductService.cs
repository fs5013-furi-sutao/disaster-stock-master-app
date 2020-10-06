using System.Collections.Generic;
using System.Linq;
using WebApi.Entities;
using WebApi.Helpers;

namespace WebApi.Services
{
    public interface IMstProductService
    {
        IEnumerable<MstProduct> GetAll();
        IEnumerable<MstProduct> GetByName(string name);
        MstProduct GetByCd(string cd);
    }

    public class MstProductService : IMstProductService
    {
        private DataContext _context;

        public MstProductService(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<MstProduct> GetAll()
        {
            return _context.MstProducts;
        }

        public MstProduct GetByCd(string cd)
        {
            return _context.MstProducts.Where(x => x.Cd == cd).SingleOrDefault();
        }

        public IEnumerable<MstProduct> GetByName(string name)
        {
            return _context.MstProducts.ToList().Where(x => x.Name.Contains(name));
        }
    }
}