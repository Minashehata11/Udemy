using Microsoft.EntityFrameworkCore;
using Udemy.Core.Entities;
using Udemy.Core.Specefication;

namespace Udemy.Repository
{
    public static class SpecificationEvaluator<T> where T :BaseEntity
    {
        public static IQueryable<T> GetQuery(IQueryable<T> inputQuery,ISpecefication<T> specs)
        {
            var query = inputQuery;

            if(specs.Criteria is not null)
                query=query.Where(specs.Criteria);
            if (specs.OrderBy is not null)
               query= query.OrderBy(specs.OrderBy);
            if(specs.OrderByDescinding is not null)
              query=  query.OrderByDescending(specs.OrderByDescinding);
            if(specs.IsPaginated)
                query= query.Skip(specs.Skip).Take(specs.Take); 
            query=specs.Includes.Aggregate(query,(CurrentQuery,IncludeExpression)=>CurrentQuery.Include(IncludeExpression));

            return query;   
        }

    }
}
