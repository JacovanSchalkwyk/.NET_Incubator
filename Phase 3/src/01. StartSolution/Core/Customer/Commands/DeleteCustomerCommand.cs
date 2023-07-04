namespace Core.Customer.Commands;

public class DeleteCustomerCommand : IRequest<Result>
{
	public int? Id { get; set; }

	public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, Result>
	{
		private readonly DatabaseContext databaseContext;

		public DeleteCustomerCommandHandler(DatabaseContext databaseContext)
		{
			this.databaseContext = databaseContext;
		}
		public async Task<Result> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
		{
			if (request.Id == null)
			{
				return Result.Failure("Error");
			}

			var result = await databaseContext.Customers
				.Where(u => u.Id == request.Id)
				.ExecuteDeleteAsync(cancellationToken);

			return result > 0 ? Result.Success() : Result.Failure("Error");

		}
	}
}