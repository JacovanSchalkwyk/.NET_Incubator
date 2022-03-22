﻿namespace Pezza.Core.Product.Queries
{
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using Pezza.Common.DTO;
    using Pezza.Common.Models;
    using Pezza.DataAccess.Contracts;

    public class GetProductsQuery : IRequest<ListResult<ProductDTO>>
    {
        public ProductDTO SearchModel { get; set; }
    }

    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, ListResult<ProductDTO>>
    {
        private readonly IDataAccess<ProductDTO> dataAccess;

        public GetProductsQueryHandler(IDataAccess<ProductDTO> dataAccess) => this.dataAccess = dataAccess;

        public async Task<ListResult<ProductDTO>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
            => await this.dataAccess.GetAllAsync(request.SearchModel);
    }
}
