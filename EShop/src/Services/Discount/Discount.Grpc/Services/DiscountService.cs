using Discount.Grpc.Data;
using Discount.Grpc.Models;
using Grpc.Core;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Discount.Grpc.Services
{
    public class DiscountService
        (DiscountDbContext discountDbContext, ILogger<DiscountService> logger)
        : DiscountProtoService.DiscountProtoServiceBase
    {
        public override async Task<CouponModel> GetDiscount(GetDiscountRequest request, ServerCallContext context)
        {
            var coupon = await discountDbContext.Coupons
                .FirstOrDefaultAsync(c => c.ProductName == request.ProductName);

            if (coupon is null)
            {
                coupon = new() { ProductName = "No Discount", Amount = 0, Description = "No Discount" };
            }

            var response = coupon.Adapt<CouponModel>();

            return response;
        }

        public override async Task<CouponModel> CreateDiscount(CreateDiscountRequest request, ServerCallContext context)
        {
            var coupon = request.Coupon.Adapt<Coupon>();

            if (coupon is null)
            {
                throw new RpcException(new Status(StatusCode.InvalidArgument, "Invalid request object"));
            }

            discountDbContext.Add(coupon);
            await discountDbContext.SaveChangesAsync(context.CancellationToken);

            var response = coupon.Adapt<CouponModel>();

            return response;
        }

        public override Task<CouponModel> UpdateDiscount(UpdateDiscountRequest request, ServerCallContext context)
        {
            return base.UpdateDiscount(request, context);
        }

        public override Task<DeleteDiscountResponse> DeleteDiscount(DeleteDiscountRequest request, ServerCallContext context)
        {
            return base.DeleteDiscount(request, context);
        }
    }
}
