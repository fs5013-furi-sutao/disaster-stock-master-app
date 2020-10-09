using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Entities;
using WebApi.Helpers;

namespace WebApi.Services
{
    public interface IMstDisasterStockService
    {
        MstDisasterStock Create(MstDisasterStock disasterStock);
        void Update(MstDisasterStock param);
        MstDisasterStock GetById(int id);
        IEnumerable<MstDisasterStock> GetBySearchConditions(
            string productCd, string savingStockKbn, DateTime? stockStartDate, DateTime? stockEndDate);
    }

    public class MstDisasterStockService : IMstDisasterStockService
    {
        private DataContext _context;

        public MstDisasterStockService(DataContext context)
        {
            _context = context;
        }

        public MstDisasterStock Create(MstDisasterStock disasterStock)
        {
            _context.MstDisasterStocks.Add(disasterStock);
            _context.SaveChanges();

            return disasterStock;
        }

        public MstDisasterStock GetById(int id)
        {
            return _context.MstDisasterStocks.Find(id);
        }

        public void Update(MstDisasterStock param)
        {
            MstDisasterStock mstDisasterStock = _context.MstDisasterStocks.Find(param.Id);

            if (mstDisasterStock == null)
                throw new AppException("User not found");

            _context.MstDisasterStocks.Update(param);
            _context.SaveChanges();
        }

        public IEnumerable<MstDisasterStock> GetBySearchConditions(
            string productCd, string savingStockKbn, DateTime? stockStartDate, DateTime? stockEndDate)
        {
            return _context.MstDisasterStocks
            .Where(x => productCd == "" || x.ProductCd == productCd)
            .Where(x => savingStockKbn == "" || x.SavingStockKbn == savingStockKbn)
            .Where(x => stockStartDate == null || x.StockStartDate >= stockStartDate)
            .Where(x => stockEndDate == null || x.StockEndDate <= stockEndDate)
            .OrderBy(x => x.Id).ToList();
        }
    }
}