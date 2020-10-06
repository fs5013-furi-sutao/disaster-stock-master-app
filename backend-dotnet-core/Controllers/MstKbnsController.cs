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
    public class MstKbnsController : ControllerBase
    {
        private IMstKbnService _mstKbnService;
        private IMapper _mapper;
        private readonly AppSettings _appSettings;

        public MstKbnsController(
            IMstKbnService mstKbnService,
            IMapper mapper,
            IOptions<AppSettings> appSettings)
        {
            _mstKbnService = mstKbnService;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        /// <summary>
        /// 指定の区分である区分リストを返却する
        /// </summary>
        /// <returns>条件に合う区分のリスト</returns>
        /// <response code="200">条件に合う区分のリスト</response>
        [HttpGet("kbn/{kbn}")]
        public IActionResult GetByKbn(string kbn = "")
        {
            IEnumerable<MstKbn> mstKbns = _mstKbnService.GetByKbn(kbn);
            IList<MstKbnModel> model = _mapper.Map<IList<MstKbnModel>>(mstKbns);
            return Ok(model);
        }
    }
}
