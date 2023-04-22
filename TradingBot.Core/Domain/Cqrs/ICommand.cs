using MediatR;

namespace TradingBot.Core.Domain.Cqrs
{
    public interface ICommand<TResponse> : IRequest<TResponse>
    {

    }
}
