﻿namespace Pezza.Core.Stock.Queries
{
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using Pezza.Common.DTO;
    using Pezza.Common.Models;
    using Pezza.DataAccess.Contracts;

    public class GetStocksQuery : IRequest<ListResult<StockDTO>>
    {
        public StockDTO dto;
    }

    public class GetStocksQueryHandler : IRequestHandler<GetStocksQuery, ListResult<StockDTO>>
    {
        private readonly IDataAccess<StockDTO> dto;

        public GetStocksQueryHandler(IDataAccess<StockDTO> dto) => this.dto = dto;

        public async Task<ListResult<StockDTO>> Handle(GetStocksQuery request, CancellationToken cancellationToken)
        {
            var search = await this.dto.GetAllAsync(request.dto);
            return search;
        }
    }
}
