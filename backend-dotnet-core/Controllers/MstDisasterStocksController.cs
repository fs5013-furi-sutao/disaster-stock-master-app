using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using WebApi.Helpers;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authorization;
using WebApi.Services;
using WebApi.Entities;
using WebApi.Models.Products;
using System;

namespace WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class MstDisasterStocksController : ControllerBase
    {
        private IMstDisasterStockService _mstDisasterStockService;
        private IMapper _mapper;
        private readonly AppSettings _appSettings;

        public MstDisasterStocksController(
            IMstDisasterStockService mstDisasterStockService,
            IMapper mapper,
            IOptions<AppSettings> appSettings)
        {
            _mstDisasterStockService = mstDisasterStockService;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        /// <summary>
        /// 指定の条件である災害備蓄リストを返却する
        /// </summary>
        /// <returns>条件に合う災害備蓄のリスト</returns>
        /// <response code="200">条件に合う災害備蓄のリスト</response>
        [HttpGet("conditions")]
        public IActionResult GetBySearchConditions(
            [FromQuery] string productCd = "", [FromQuery] string savingStockKbn = "",
            [FromQuery] DateTime? stockStartDate = null, [FromQuery] DateTime? stockEndDate = null)
        {
            IEnumerable<MstDisasterStock> mstDisasterStocks = _mstDisasterStockService.GetBySearchConditions(
                productCd, savingStockKbn, stockStartDate, stockEndDate);
            IList<MstDisasterStock> model = _mapper.Map<IList<MstDisasterStock>>(mstDisasterStocks);
            return Ok(model);
        }
    }
}
