using System.Collections.Generic;
using System.Linq;
using WebApi.Entities;
using WebApi.Helpers;

namespace WebApi.Services
{
    public interface IMstProductService
    {
        IEnumerable<MstProduct> GetAll();
        MstProduct GetById(int id);
        MstProduct GetByCd(string cd);
        IEnumerable<MstProduct> GetByName(string name);
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

        public MstProduct GetById(int id)
        {
            return _context.MstProducts.Where(x => x.Id == id).SingleOrDefault();
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