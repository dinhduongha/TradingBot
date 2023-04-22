using System.Linq.Expressions;

namespace TradingBot.Core.Specification
{
    public interface IEqualSpecification<TEntity> : IRootSpecification
    {
        Expression<Func<TEntity, bool>> IsEqual { get; }
    }
}
