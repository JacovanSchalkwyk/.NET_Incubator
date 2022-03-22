﻿namespace Pezza.Core.Stock.Commands
{
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using Pezza.Common.DTO;
    using Pezza.Common.Models;
    using Pezza.DataAccess.Contracts;

    public partial class UpdateStockCommand : IRequest<Result<StockDTO>>
    {
        public StockDTO Data { get; set; }
    }

    public class UpdateStockCommandHandler : IRequestHandler<UpdateStockCommand, Result<StockDTO>>
    {
        private readonly IDataAccess<StockDTO> dataAccess;

        public UpdateStockCommandHandler(IDataAccess<StockDTO> dataAccess) => this.dataAccess = dataAccess;

        public async Task<Result<StockDTO>> Handle(UpdateStockCommand request, CancellationToken cancellationToken)
        {
            var outcome = await this.dataAccess.UpdateAsync(request.Data);
            return (outcome != null) ? Result<StockDTO>.Success(outcome) : Result<StockDTO>.Failure("Error updating a Stock");
        }
    }
}