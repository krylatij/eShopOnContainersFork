using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Coupon.API.Dto;
using global.Coupon.API.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Coupon.API.Controllers
{
    [Route("api/v1/[controller]")]
    [Authorize]
    [ApiController]
    public class CouponController : ControllerBase
    {
        private readonly ICouponRepository _repository;

        public CouponController(ICouponRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{code}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CouponDto>> GetCouponByCodeAsync(string code)
        {
            var coupon = await _repository.FindCouponByCodeAsync(code);

            if (coupon is null || coupon.Consumed)
            {
                return NotFound();
            }

            var couponDto = _mapper.Translate(coupon);

            return couponDto;
        }
    }
}
