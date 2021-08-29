using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coupon.API.Infrastructure.Models
{
    public class Coupon
    {
        public Guid Id { get; set; }

        public int Discount { get; set; }

        public string Code { get; set; }

        public bool Consumed { get; set; }

        public Guid? OrderId { get; set; }
    }
}
