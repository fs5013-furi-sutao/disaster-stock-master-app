using System.Collections.Generic;
using System.Linq;
using WebApi.Entities;
using WebApi.Helpers;

namespace WebApi.Services
{
    public interface IMstPrefService
    {
        IEnumerable<MstPref> GetAll();
        MstPref GetByCd(string cd);
        IEnumerable<MstPref> GetByName(string name);
    }

    public class MstPrefService : IMstPrefService
    {
        private DataContext _context;

        public MstPrefService(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<MstPref> GetAll()
        {
            return _context.MstPrefs;
        }

        public MstPref GetByCd(string cd)
        {
            return _context.MstPrefs.ToList().Where(x => x.Cd == cd).SingleOrDefault();
        }
        public IEnumerable<MstPref> GetByName(string name)
        {
            return _context.MstPrefs.ToList().Where(x => x.Name.Contains(name));
        }
    }
}