using MediatR;

namespace eu.greenmaster.Contracts.Queries;

public class QueryBase<T> : IRequest<T> where T : class
{
}
