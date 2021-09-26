using Microsoft.Extensions.Logging;

namespace Coupon.API.Controllers
{
    using System.Net;
    using System.Threading.Tasks;
    using Coupon.API.Dtos;
    using Coupon.API.Infrastructure.Models;
    using Coupon.API.Infrastructure.Repositories;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CouponController : ControllerBase
    {
        private readonly ICouponRepository _couponRepository;
        private readonly IMapper<CouponDto, Coupon> _mapper;
        private readonly ILogger<CouponController> _logger;

        public CouponController(ICouponRepository couponRepository, IMapper<CouponDto, Coupon> mapper, ILogger<CouponController> logger)
        {
            _couponRepository = couponRepository;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet("{code}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CouponDto>> GetCouponByCodeAsync(string code)
        {
            _logger.LogInformation($"Getting coupon with code '{code}'.");
            var coupon = await _couponRepository.FindCouponByCodeAsync(code);

            if (coupon is null || coupon.Consumed)
            {
                _logger.LogInformation($"Coupon with code '{code}' was not found.");
                return NotFound("Not found or consumed");
            }

            var couponDto = _mapper.Translate(coupon);

            _logger.LogInformation($"Coupon with code '{code}' was found.");
            return couponDto;
        }
    }
}
