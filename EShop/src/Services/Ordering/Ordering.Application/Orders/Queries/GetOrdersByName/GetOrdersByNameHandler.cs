﻿using BuildingBlocks.CQRS;
using Microsoft.EntityFrameworkCore;
using Ordering.Application.Data;
using Ordering.Application.Extensions;

namespace Ordering.Application.Orders.Queries.GetOrdersByName
{
    public class GetOrdersByNameHandler
        (IApplicationDbContext applicationDbContext)
        : IQueryHandler<GetOrdersByNameQuery, GetOrdersByNameResult>
    {
        public async Task<GetOrdersByNameResult> Handle(GetOrdersByNameQuery query, CancellationToken cancellationToken)
        {
            var orders = await applicationDbContext.Orders
                .Include(o => o.OrderItems)
                .Where(o => o.OrderName.Value.Contains(query.Name))
                .OrderBy(o => o.OrderName)
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            return new GetOrdersByNameResult(orders.ToOrderDtoList());
        }
    }
}