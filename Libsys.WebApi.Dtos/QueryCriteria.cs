using Apstars;
using Apstars.Querying;
using System;

namespace Libsys.WebApi.Dtos
{
    public class QueryCriteria<TKey, TAggregateRoot>
        where TAggregateRoot : class, IAggregateRoot<TKey>, new()
        where TKey : IEquatable<TKey>
    {
        public string FilterExpression { get; set; }

        public object[] expressionArgs { get; set; }

        public int? PageSize { get; set; }

        public int? PageNumber { get; set; }
        
        public SortSpecification<TKey, TAggregateRoot> sortSpecification { get; set; }        
    }


    public class QueryCriteria<TAggregateRoot> : QueryCriteria<Guid, TAggregateRoot>
        where TAggregateRoot : class, IAggregateRoot<Guid>, new()
    {

    }
}
