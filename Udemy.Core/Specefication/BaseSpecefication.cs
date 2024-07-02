using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Udemy.Core.Entities;

namespace Udemy.Core.Specefication
{
    public class BaseSpecefication<T> : ISpecefication<T> where T : BaseEntity
    {
        public Expression<Func<T, bool>> Criteria { get; set; }
        public List<Expression<Func<T, object>>> Includes { get; set ; } = new List<Expression<Func<T, object>>> ();
        public Expression<Func<T, object>> OrderBy { get ; set; }
        public Expression<Func<T, object>> OrderByDescinding { get ; set; }
        public int Take { get ; set ; }
        public int Skip { get; set; }
        public bool IsPaginated { get; set; }
        public BaseSpecefication()
        {
            
        }
        public BaseSpecefication(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }
        public void AddOrderBy(Expression<Func<T, object>> orderBy)
        {
            OrderBy = orderBy;
        }
        public void AddOrderByDesc(Expression<Func<T, object>> orderByDescending)
        {
            OrderBy = orderByDescending;
        }
        public void AddPaginated(int skip, int take)
        {
            IsPaginated = true;
            Skip = skip;
            Take = take;
        }
    }
}
