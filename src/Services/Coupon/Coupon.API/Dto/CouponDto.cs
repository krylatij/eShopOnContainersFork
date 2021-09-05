using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coupon.API.Dto
{
    public class CouponDto
    {
        public Guid Id { get; set; }

        public int Discount { get; set; }

        public string Code { get; set; }

        public bool Consumed { get; set; }
    }
}
