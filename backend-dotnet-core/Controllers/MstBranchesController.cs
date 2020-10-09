using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using WebApi.Helpers;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authorization;
using WebApi.Services;
using WebApi.Entities;
using WebApi.Models.Manufactures;
using WebApi.Models.Branches;

namespace WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class MstBranchesController : ControllerBase
    {
        private IMstBranchService _mstBranchService;
        private IMapper _mapper;
        private readonly AppSettings _appSettings;

        public MstBranchesController(
            IMstBranchService mstBranchService,
            IMapper mapper,
            IOptions<AppSettings> appSettings)
        {
            _mstBranchService = mstBranchService;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        /// <summary>
        /// すべての支店を返却する
        /// </summary>
        /// <returns>全支店のリスト</returns>
        /// <response code="200">全支店のリスト</response>
        [HttpGet]
        public IActionResult GetAll()
        {
            IEnumerable<MstBranch> mstBranches = _mstBranchService.GetAll();
            IList<MstBranchModel> model = _mapper.Map<IList<MstBranchModel>>(mstBranches);
            return Ok(model);
        }

        /// <summary>
        /// コードが指定の値である支店を返却する
        /// </summary>
        /// <returns>指定条件に合う支店</returns>
        /// <response code="200">指定条件に合う支店</response>
        [HttpGet("cd/{cd?}")]
        public IActionResult GetByCd(string cd = "")
        {
            MstBranch mstBranch = _mstBranchService.GetByCd(cd);
            MstBranchModel model = _mapper.Map<MstBranchModel>(mstBranch);
            return Ok(model);
        }

        /// <summary>
        /// 指定のキーワードが含まれる名前の支店を返却する
        /// </summary>
        /// <returns>条件に合う支店のリスト</returns>
        /// <response code="200">条件に合う支店のリスト</response>
        [HttpGet("name/{name?}")]
        public IActionResult GetByName(string name = "")
        {
            IEnumerable<MstBranch> mstBranches = _mstBranchService.GetByName(name);
            IList<MstBranchModel> model = _mapper.Map<IList<MstBranchModel>>(mstBranches);
            return Ok(model);
        }
    }
}
