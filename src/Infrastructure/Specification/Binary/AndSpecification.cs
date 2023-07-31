using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using LinqKit;

namespace Infrastructure.Specification.Binary
{
    public class AndSpecification<T> : BinarySpecification<T>
    {
        public AndSpecification(ISpecification<T> left, ISpecification<T> right) : base(left, right)
        {
        }

        public override bool IsSatisfiedBy(T condition)
        {
            return LeftSide.IsSatisfiedBy(condition) && RightSide.IsSatisfiedBy(condition);
        }

        public override Expression<Func<T, bool>> IsSatisfiedBy()
        {
            //var body = Expression.AndAlso(LeftSide.IsSatisfiedBy().Body, RightSide.IsSatisfiedBy().Body);
            //var lambda = Expression.Lambda<Func<T,bool>>(body, LeftSide.IsSatisfiedBy().Parameters);
            var lambda = PredicateBuilder.And(LeftSide.IsSatisfiedBy(), RightSide.IsSatisfiedBy());

            return lambda.Expand();
        }
    }

}
