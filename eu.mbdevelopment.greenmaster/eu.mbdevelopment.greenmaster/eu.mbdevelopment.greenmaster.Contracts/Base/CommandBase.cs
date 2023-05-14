using MediatR;

namespace eu.mbdevelopment.greenmaster.Contracts.Base;

public class CommandBase<T> : IRequest<T> where T : class
{

}
