using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using WebApi.Helpers;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authorization;
using WebApi.Services;
using WebApi.Entities;
using WebApi.Models.Manufactures;

namespace WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class MstManufacturesController : ControllerBase
    {
        private IMstManufactureService _mstManufactureService;
        private IMapper _mapper;
        private readonly AppSettings _appSettings;

        public MstManufacturesController(
            IMstManufactureService mstManufactureService,
            IMapper mapper,
            IOptions<AppSettings> appSettings)
        {
            _mstManufactureService = mstManufactureService;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        /// <summary>
        /// すべてのメーカーを返却する
        /// </summary>
        /// <returns>全メーカーのリスト</returns>
        /// <response code="200">全メーカーのリスト</response>
        [HttpGet]
        public IActionResult GetAll()
        {
            var mstManufactures = _mstManufactureService.GetAll();
            var model = _mapper.Map<IList<MstManufactureModel>>(mstManufactures);
            return Ok(model);
        }

        /// <summary>
        /// コードが指定の値であるメーカーを返却する
        /// </summary>
        /// <returns>指定条件に合うメーカー</returns>
        /// <response code="200">指定条件に合うメーカー</response>
        [HttpGet("cd/{cd?}")]
        public IActionResult GetByCd(string cd = "")
        {
            MstManufacture mstManufacture = _mstManufactureService.GetByCd(cd);
            MstManufactureModel model = _mapper.Map<MstManufactureModel>(mstManufacture);
            return Ok(model);
        }
    }
}
