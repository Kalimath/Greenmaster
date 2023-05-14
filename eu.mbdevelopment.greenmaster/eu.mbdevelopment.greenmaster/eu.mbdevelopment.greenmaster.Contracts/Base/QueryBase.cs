using MediatR;

namespace eu.mbdevelopment.greenmaster.Contracts.Base;

public class QueryBase<T> : IRequest<T> where T : class
{
}