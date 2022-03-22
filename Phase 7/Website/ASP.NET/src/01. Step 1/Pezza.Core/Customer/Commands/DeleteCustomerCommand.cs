﻿namespace Pezza.Core.Customer.Commands
{
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using Pezza.Common.DTO;
    using Pezza.Common.Models;
    using Pezza.DataAccess.Contracts;

    public partial class DeleteCustomerCommand : IRequest<Result>
    {
        public int Id { get; set; }
    }

    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, Result>
    {
        private readonly IDataAccess<CustomerDTO> dataAccess;

        public DeleteCustomerCommandHandler(IDataAccess<CustomerDTO> dataAccess)
            => this.dataAccess = dataAccess;

        public async Task<Result> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var outcome = await this.dataAccess.DeleteAsync(request.Id);

            return outcome ? Result.Success() : Result.Failure("Error deleting a Customer");
        }
    }
}
