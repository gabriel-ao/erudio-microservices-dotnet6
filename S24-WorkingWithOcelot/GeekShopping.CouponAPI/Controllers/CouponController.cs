using GeekShopping.CouponAPI.Data.ValueObjects;
using GeekShopping.CouponAPI.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.CouponAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CouponController : ControllerBase
    {
        private ICouponRepository _repository;

        public CouponController(ICouponRepository repository)
        {
            // se tiver nulo, estoura a Exception
            _repository = repository ?? throw new 
                ArgumentNullException(nameof(repository));
        }


        [HttpGet("{couponCode}")]
        //[Authorize]
        public async Task<ActionResult<CouponVO>> GetCoupon(string couponCode)
        {
            // todo - entender o pq de o authorize nao estar funcionando
            var coupon = await _repository.GetCoupon(couponCode);
            if (coupon.Id <= 0) return NotFound();
            return Ok(coupon);
        }

    }
}