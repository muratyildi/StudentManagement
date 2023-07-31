using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Specification
{
    public class AnonymousSpecification<T> : Specification<T>
    {
        private readonly Expression<Func<T, bool>> _conditionExpression;

        public AnonymousSpecification(Expression<Func<T, bool>> conditionExpression)
        {
            this._conditionExpression = conditionExpression;
        }

        public override bool IsSatisfiedBy(T value)
        {
            return _conditionExpression.Compile().Invoke(value);
        }

        public override Expression<Func<T, bool>> IsSatisfiedBy()
        {
            return _conditionExpression;
        }
    }

}
