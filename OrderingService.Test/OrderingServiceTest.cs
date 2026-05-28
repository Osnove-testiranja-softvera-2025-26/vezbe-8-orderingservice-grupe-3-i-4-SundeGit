using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingService.Test
{
    [TestFixture]
    internal class OrderingServiceTest
    {
        private FakeOrderService fakeOrderService;
        private FakeCouponService fakeCouponService;
        private FakeLoggerService fakeLoggerService;

        [SetUp]
        public void SetUp()
        {
            fakeOrderService = new FakeOrderService();
            fakeCouponService = new FakeCouponService();
            fakeLoggerService = new FakeLoggerService();
            calculationService = new CalculatioService(fakeOrderService, fakeCouponService);
            calculationService.LoggerService = fakeLoggerService;
        }


        [TestCase(5, 400, 300, false, true)];
        [TestCase(-3, 400, 300, false, false)];
        [TestCase(5, 200, 300, false, false)];
        [TestCase(5, 400, 300, true, false)];

        public void CheckCouponVadility_CouponValid_Success(int expirationDateHours, double orderTotal, double couponMinimalRequiredOrderTotal, bool couponUsed, bool expected)
        {
            fakeOrderService.Orders = new List<Order>
            {
                new Order
                {
                   Total = orderTotal,
                }
            }

            fakeCouponService.Coupon = new Coupon
            {
                ExpirationDate = DateTime.Now.AddHours(expirationDateHours),
                MinimalRequiredOrderTotal = couponMinimalRequiredOrderTotal,
                couponUsed = couponUsed
            };

            bool actual = calculationService.CheckCouponValidity(Guid.NewGuid(), Guid.NewGuid());

            Assert.AreEqual(expected, actual);
        }
    }
}
