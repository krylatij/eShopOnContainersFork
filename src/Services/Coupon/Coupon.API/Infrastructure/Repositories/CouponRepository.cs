using System;
using System.Threading.Tasks;
using Coupon = Coupon.API.Infrastructure.Models.Coupon;
using ICouponRepository = global.Coupon.API.Infrastructure.Repositories.ICouponRepository;

namespace global::Coupon.API.Infrastructure.Repositories
{
    public class CouponRepository : ICouponRepository
    {
        public async Task<global::Coupon.API.Infrastructure.Models.Coupon> FindCouponByCodeAsync(string code)
        {
            return new global::Coupon.API.Infrastructure.Models.Coupon
            {
                Id = Guid.NewGuid(),
                Code = code
            };
        }
    }
}
