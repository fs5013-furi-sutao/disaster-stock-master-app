using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Entities;
using WebApi.Helpers;

namespace WebApi.Services
{
    public interface IMstDisasterStockService
    {
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