using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Specification.Unary
{
    public class NotSpecification<T> : Specification<T>
    {
        private readonly ISpecification<T> _toNegate;

        public NotSpecification(ISpecification<T> toNegate)
        {
            this._toNegate = toNegate;
        }

        public override bool IsSatisfiedBy(T condition)
        {
            return !_toNegate.IsSatisfiedBy(condition);
        }

        public override Expression<Func<T, bool>> IsSatisfiedBy()
        {
            var body = Expression.Not(_toNegate.IsSatisfiedBy().Body);
            var lambda = Expression.Lambda<Func<T, bool>>(body, _toNegate.IsSatisfiedBy().Parameters);

            return lambda;
        }
    }

}
