using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using WebApi.Helpers;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authorization;
using WebApi.Services;
using WebApi.Entities;
using WebApi.Models.Manufactures;
using WebApi.Models.Prefs;

namespace WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class MstPrefsController : ControllerBase
    {
        private IMstPrefService _mstPrefService;
        private IMapper _mapper;
        private readonly AppSettings _appSettings;

        public MstPrefsController(
            IMstPrefService mstPrefService,
            IMapper mapper,
            IOptions<AppSettings> appSettings)
        {
            _mstPrefService = mstPrefService;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        /// <summary>
        /// すべての県を返却する
        /// </summary>
        /// <returns>全県のリスト</returns>
        /// <response code="200">全県のリスト</response>
        [HttpGet]
        public IActionResult GetAll()
        {
            IEnumerable<MstPref> mstPrefs = _mstPrefService.GetAll();
            IList<MstManufactureModel> model = _mapper.Map<IList<MstManufactureModel>>(mstPrefs);
            return Ok(model);
        }

        /// <summary>
        /// コードが指定の値である県を返却する
        /// </summary>
        /// <returns>指定条件に合う県</returns>
        /// <response code="200">指定条件に合う県</response>
        [HttpGet("cd/{cd?}")]
        public IActionResult GetByCd(string cd = "")
        {
            MstPref mstPref = _mstPrefService.GetByCd(cd);
            MstPrefModel model = _mapper.Map<MstPrefModel>(mstPref);
            return Ok(model);
        }

        /// <summary>
        /// 指定のキーワードが含まれる名前の県情報を返却する
        /// </summary>
        /// <returns>条件に合う県情報のリスト</returns>
        /// <response code="200">条件に合う県情報のリスト</response>
        [HttpGet("name/{name?}")]
        public IActionResult GetByName(string name = "")
        {
            IEnumerable<MstPref> mstPrefs = _mstPrefService.GetByName(name);
            IList<MstPrefModel> model = _mapper.Map<IList<MstPrefModel>>(mstPrefs);
            return Ok(model);
        }
    }
}
