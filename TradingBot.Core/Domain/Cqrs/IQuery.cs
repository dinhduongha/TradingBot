using MediatR;

namespace TradingBot.Core.Domain.Cqrs
{
    public interface IQuery<TResponse> : IRequest<TResponse>
    {

    }
}
