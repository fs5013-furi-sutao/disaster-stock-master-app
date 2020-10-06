using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using WebApi.Helpers;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authorization;
using WebApi.Services;
using WebApi.Entities;
using WebApi.Models.Products;

namespace WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class MstProductsController : ControllerBase
    {
        private IMstProductService _mstProductService;
        private IMapper _mapper;
        private readonly AppSettings _appSettings;

        public MstProductsController(
            IMstProductService mstProductService,
            IMapper mapper,
            IOptions<AppSettings> appSettings)
        {
            _mstProductService = mstProductService;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        /// <summary>
        /// すべての商品を返却する
        /// </summary>
        /// Sample request:
        /// <returns>全商品のリスト</returns>
        /// <response code="200">全商品のリスト</response>
        [HttpGet]
        public IActionResult GetAll()
        {
            IEnumerable<MstProduct> mstProducts = _mstProductService.GetAll();
            IList<MstProductModel> model = _mapper.Map<IList<MstProductModel>>(mstProducts);
            return Ok(model);
        }

        /// <summary>
        /// 指定のキーワードが含まれる名前の商品を返却する
        /// </summary>
        /// <returns>条件に合う商品のリスト</returns>
        /// <response code="200">条件に合う商品のリスト</response>
        [HttpGet("name/{name?}")]
        public IActionResult GetByName(string name = "")
        {
            IEnumerable<MstProduct> mstProducts = _mstProductService.GetByName(name);
            IList<MstProductModel> model = _mapper.Map<IList<MstProductModel>>(mstProducts);
            return Ok(model);
        }

        /// <summary>
        /// 指定のコードが含まれる名前の商品を返却する
        /// </summary>
        /// <returns>条件に合う商品のリスト</returns>
        /// <response code="200">条件に合う商品のリスト</response>
        [HttpGet("cd/{cd}")]
        public IActionResult GetByCd(string cd)
        {
            MstProduct mstProduct = _mstProductService.GetByCd(cd);
            MstProductModel model = _mapper.Map<MstProductModel>(mstProduct);
            return Ok(model);
        }
    }
}
