using Apstars;
using Apstars.Application.Dto;
using System;
using System.Linq;

namespace Libsys.Common
{
    /// <summary>
    /// Represents the method extender.
    /// </summary>
    public static class MethodExtender
    {
        /// <summary>
        /// Casts the specified source.
        /// </summary>
        /// <typeparam name="TAggregateRoot">The type of the aggregate root.</typeparam>
        /// <typeparam name="TDto">The type of the dto.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="mapping">The mapping.</param>
        /// <returns></returns>
        public static PagedResultDto<TKey, TDto> CastPagedResult<TKey, TAggregateRoot, TDto>(this PagedResult<TKey, TAggregateRoot> source, Func<TAggregateRoot, TDto> mapping)
            where TKey : IEquatable<TKey>
            where TAggregateRoot : class, IAggregateRoot<TKey>, new()
            where TDto : class, IEntityDto<TKey>, new()
        {
            return new PagedResultDto<TKey, TDto>(source.TotalRecords,
                source.TotalPages, source.PageSize, source.PageNumber,
                source.Entities.Select(mapping).ToList());
        }

        /// <summary>
        /// Casts the specified source.
        /// </summary>
        /// <typeparam name="TAggregateRoot">The type of the aggregate root.</typeparam>
        /// <typeparam name="TDto">The type of the dto.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="mapping">The mapping.</param>
        /// <returns></returns>
        public static PagedResultDto<TDto> CastPagedResult<TAggregateRoot, TDto>(this PagedResult<Guid, TAggregateRoot> source, Func<TAggregateRoot, TDto> mapping)           
            where TAggregateRoot : class, IAggregateRoot<Guid>, new()
            where TDto : class, IEntityDto<Guid>, new()
        {
            return new PagedResultDto<TDto>(source.TotalRecords,
                source.TotalPages, source.PageSize, source.PageNumber,
                source.Entities.Select(mapping).ToList());
        }

        /// <summary>
        /// Casts the specified source.
        /// </summary>
        /// <typeparam name="TAggregateRoot">The type of the aggregate root.</typeparam>
        /// <typeparam name="TDto">The type of the dto.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="mapping">The mapping.</param>
        /// <returns></returns>
        public static PagedResultDto<TDto> CastPagedResult<TAggregateRoot, TDto>(this PagedResult<TAggregateRoot> source, Func<TAggregateRoot, TDto> mapping)            
            where TAggregateRoot : class, IAggregateRoot, new()
            where TDto : class, IEntityDto, new()
        {
            return new PagedResultDto<TDto>(source.TotalRecords,
                source.TotalPages, source.PageSize, source.PageNumber,
                source.Entities.Select(mapping).ToList());
        }
    }
}
