using System.Threading.Tasks;

namespace global.Coupon.API.Infrastructure.Repositories
{
    public interface ICouponRepository
    {
        Task<global::Coupon.API.Infrastructure.Models.Coupon> FindCouponByCodeAsync(string code);
    }
}