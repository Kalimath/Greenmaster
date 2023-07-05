using MediatR;

namespace Greenmaster.Contracts.Base;

public class CommandBase<T> : IRequest<T> where T : class
{

}