﻿using Application.Features.Models.Models;
using Application.Features.Models.Queries.GetListModel;
using Application.Features.Models.Queries.GetListModelByDynamic;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelsController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
        {
            GetListModelQuery getListModelQuery = new() { PageRequest = pageRequest };
            ModelListModel modelListModel = await Mediator.Send(getListModelQuery);
            return Ok(modelListModel);
        }
        [HttpPost("GetList/ByDynamic")]
        public async Task<IActionResult> GetListByDynamicAsync([FromQuery] PageRequest pageRequest, [FromBody] Dynamic dynamic)
        {
            GetListModelByDynamicQuery getListModelByDynamicQuery = new() { PageRequest = pageRequest, Dynamic = dynamic };
            ModelListModel modelListModel = await Mediator.Send(getListModelByDynamicQuery);
            return Ok(modelListModel);
        }
    }
}
