using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS2023_V9.Fakes
{
    public class FakeCouponService : ICouponService
    {
        public Coupon {  get; set; }
        public Guid UsedCouponId { get; set; }
        public InvalidCouponException UseCouponExceptionToThrow { get; set; }

        public FakeCouponService GetCouponById(Guid id)
        {
            return Coupon;
        }
    }
}
