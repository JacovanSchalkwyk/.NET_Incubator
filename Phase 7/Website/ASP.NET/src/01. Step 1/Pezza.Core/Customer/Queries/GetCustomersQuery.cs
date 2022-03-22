﻿namespace Pezza.Core.Customer.Queries
{
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using Pezza.Common.DTO;
    using Pezza.Common.Models;
    using Pezza.DataAccess.Contracts;

    public class GetCustomersQuery : IRequest<ListResult<CustomerDTO>>
    {
        public CustomerDTO SearchModel { get; set; }
    }

    public class GetCustomersQueryHandler : IRequestHandler<GetCustomersQuery, ListResult<CustomerDTO>>
    {
        private readonly IDataAccess<CustomerDTO> dataAccess;

        public GetCustomersQueryHandler(IDataAccess<CustomerDTO> dataAccess) => this.dataAccess = dataAccess;

        public async Task<ListResult<CustomerDTO>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
            => await this.dataAccess.GetAllAsync(request.SearchModel);
    }
}
