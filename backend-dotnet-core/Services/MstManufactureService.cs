using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Entities;
using WebApi.Helpers;

namespace WebApi.Services
{
    public interface IMstManufactureService
    {
        IEnumerable<MstManufacture> GetAll();
        MstManufacture GetByCd(string cd);
    }

    public class MstManufactureService : IMstManufactureService
    {
        private DataContext _context;

        public MstManufactureService(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<MstManufacture> GetAll()
        {
            return _context.MstManufactures;
        }

        public MstManufacture GetByCd(string cd)
        {
            return _context.MstManufactures.ToList().Where(x => x.Cd == cd).SingleOrDefault();
        }
    }
}