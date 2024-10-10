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

            logger.LogInformation("Discount is retreived for ProductName: {productName}, Amount: {amount}",
                coupon.ProductName, coupon.Amount);

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

            logger.LogInformation("Discount is successfully created. ProductName: {productName}",
                coupon.ProductName);

            var response = coupon.Adapt<CouponModel>();

            return response;
        }

        public override async Task<CouponModel> UpdateDiscount(UpdateDiscountRequest request, ServerCallContext context)
        {
            var coupon = request.Coupon.Adapt<Coupon>();

            if (coupon is null)
            {
                throw new RpcException(new Status(StatusCode.InvalidArgument, "Invalid request object"));
            }

            discountDbContext.Update(coupon);
            await discountDbContext.SaveChangesAsync(context.CancellationToken);

            logger.LogInformation("Discount is successfully updated. ProductName: {productName}",
                coupon.ProductName);

            var response = coupon.Adapt<CouponModel>();

            return response;
        }

        public override async Task<DeleteDiscountResponse> DeleteDiscount(DeleteDiscountRequest request, ServerCallContext context)
        {
            var coupon = await discountDbContext.Coupons
                .FirstOrDefaultAsync(c => c.ProductName == request.ProductName);

            if (coupon is null)
            {
                throw new RpcException(new Status(StatusCode.NotFound,
                    $"Discount with ProductName={request.ProductName} is not found."));
            }

            discountDbContext.Coupons.Remove(coupon);
            await discountDbContext.SaveChangesAsync(context.CancellationToken);

            logger.LogInformation("Discount is successfully deleted. ProductName: {productName}",
                coupon.ProductName);

            return new DeleteDiscountResponse { IsSuccessful = true };
        }
    }
}
