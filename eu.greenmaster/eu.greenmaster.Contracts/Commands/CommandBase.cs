using MediatR;

namespace eu.greenmaster.Contracts.Commands;

public class CommandBase<T> : IRequest<T> where T : class
{

}
