using Common.Models.Customer;
using MediatR;

namespace Core.Customer.Queries;

public class GetCustomersQuery : IRequest<ListResult<CustomerModel>>
{
	public class GetCustomersQueryHandler : IRequestHandler<GetCustomersQuery, ListResult<CustomerModel>>
	{
		private readonly DatabaseContext databaseContext;

		public GetCustomersQueryHandler(DatabaseContext databaseContext)
		{
			this.databaseContext = databaseContext;
		}
		public async Task<ListResult<CustomerModel>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
		{
			var entities = databaseContext.Customers.Select(x => x).AsNoTracking();

			var count = entities.Count();
			var paged = await entities.ToListAsync(cancellationToken);

			return ListResult<CustomerModel>.Success(paged.Map(), count);
		}
	}
}