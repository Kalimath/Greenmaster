using MediatR;

namespace Greenmaster.Contracts.Base;

public class QueryBase<T> : IRequest<T> where T : class
{
}