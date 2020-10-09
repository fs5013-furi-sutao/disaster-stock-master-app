using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using WebApi.Helpers;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authorization;
using WebApi.Services;
using WebApi.Entities;
using System;
using WebApi.Models.DisasterStocks;

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

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody] MstDisasterStockModel model)
        {
            // map model to entity
            MstDisasterStock mstDisaster = _mapper.Map<MstDisasterStock>(model);

            try
            {
                // create disaster stock
                _mstDisasterStockService.Create(mstDisaster);
                return Ok(new
                {
                    Id = mstDisaster.Id,
                    Message = $"備蓄マスタ ID {mstDisaster.Id} を登録しました"
                });
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                Console.WriteLine(ex);
                return BadRequest(new { message = $"備蓄マスタ ID  {mstDisaster.Id} はすでに登録されています" });
            }
        }

        [AllowAnonymous]
        [HttpPut("update/{id}")]
        public IActionResult Update(int id, [FromBody] MstDisasterStockModel model)
        {
            // map model to entity and set id
            MstDisasterStock mstDisasterStock = _mapper.Map<MstDisasterStock>(model);
            mstDisasterStock.Id = id;

            try
            {
                // update user 
                _mstDisasterStockService.Update(mstDisasterStock);
                return Ok();
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>
        /// 指定された ID の災害備蓄マスタを返却する
        /// </summary>
        /// <returns>条件に合う災害備蓄マスタ</returns>
        /// <response code="200">条件に合う災害備蓄マスタ</response>
        [HttpGet("id/{id}")]
        public IActionResult GetById(int id)
        {
            MstDisasterStock mstDisasterStock = _mstDisasterStockService.GetById(id);
            MstDisasterStockModel model = _mapper.Map<MstDisasterStockModel>(mstDisasterStock);
            return Ok(model);
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
