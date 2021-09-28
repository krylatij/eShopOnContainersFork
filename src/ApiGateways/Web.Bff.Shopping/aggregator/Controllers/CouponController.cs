using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Grpc.Core.Logging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.eShopOnContainers.Web.Shopping.HttpAggregator.Models;
using Microsoft.eShopOnContainers.Web.Shopping.HttpAggregator.Services;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Microsoft.eShopOnContainers.Web.Shopping.HttpAggregator.Controllers
{
    [Route("api/v1/[controller]")]
    [Authorize]
    [ApiController]
    public class CouponController : ControllerBase
    {
        private readonly CouponService _coupon;
        private readonly ILogger<CouponController> _logger;

        public CouponController(CouponService coupon, ILogger<CouponController> logger)
        {
            _coupon = coupon;
            _logger = logger;
        }

        [HttpGet]
        [Route("{code}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(CouponData), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CouponData>> CheckCouponAsync(string code)
        {
            _logger.LogInformation($"Entering {nameof(CheckCouponAsync)} with code {code}");
            var response = await _coupon.CheckCouponByCodeNumberAsync(code);

            if (!response.IsSuccessStatusCode)
            {
                return NotFound("coupon not found");
            }

            var couponResponse = await response.Content.ReadAsStringAsync();

            var data = JsonConvert.DeserializeObject<CouponData>(couponResponse);

            return Ok(data);
        }
    }
}
