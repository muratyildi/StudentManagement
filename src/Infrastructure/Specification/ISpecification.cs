using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Specification
{
    public interface ISpecification<T>
    {
        bool IsSatisfiedBy(T condition);

        Expression<Func<T, bool>> IsSatisfiedBy();

        ISpecification<T> And(ISpecification<T> other);

        ISpecification<T> Or(ISpecification<T> other);

        ISpecification<T> Not();
    }

}
