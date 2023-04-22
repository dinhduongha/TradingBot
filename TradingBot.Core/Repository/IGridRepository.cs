using TradingBot.Core.Domain;
using TradingBot.Core.Specification;

namespace TradingBot.Core.Repository
{
    public interface IGridRepository
    {
        ValueTask<long> CountAsync<TEntity>(IGridSpecification<TEntity> spec) where TEntity : EntityBase, IAggregateRoot;

        Task<IEnumerable<TEntity>> FindAsync<TEntity>(IGridSpecification<TEntity> spec) where TEntity : EntityBase,
            IAggregateRoot;
    }
}
