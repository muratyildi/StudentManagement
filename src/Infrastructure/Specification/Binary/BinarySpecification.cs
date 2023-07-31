using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Specification.Binary
{
    public abstract class BinarySpecification<T> : Specification<T>
    {
        protected ISpecification<T> LeftSide;
        protected ISpecification<T> RightSide;

        protected BinarySpecification(ISpecification<T> left, ISpecification<T> right)
        {
            this.LeftSide = left;
            this.RightSide = right;
        }

        public abstract override bool IsSatisfiedBy(T value);

        public abstract override Expression<System.Func<T, bool>> IsSatisfiedBy();
    }

}
