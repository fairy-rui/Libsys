using Apstars;
using Apstars.Application.Dto;
using Apstars.Querying;
using Apstars.Repositories;
using Apstars.Specifications;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Libsys.Common;
using Libsys.Domain.Model;
using Libsys.WebApi.Dtos;
using Libsys.WebApi.Models.Exceptions;
using Libsys.WebApi.Models.Filters;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Http;
using DynamicExpression = System.Linq.Dynamic.DynamicExpression;

namespace Libsys.WebApi.Controllers
{
    /// <summary>
    /// Represents the base class for Web API controllers.
    /// </summary>
    [WebApiExceptionHandler]
    [WebApiModelValidation]
    public abstract class WebApiController : ApiController
    {
        private bool disposed;
        private readonly IRepositoryContext repositoryContext;

        private static readonly ILog log = LogManager.GetLogger("Libsys.WebApi.Logger");

        /// <summary>
        ///     Initializes a new instance of the <see cref="WebApiController" /> class.
        /// </summary>
        /// <param name="repositoryContext">The repository context.</param>
        protected WebApiController(IRepositoryContext repositoryContext)
        {
            this.repositoryContext = repositoryContext;
        }

        /// <summary>
        ///     Gets the repository context.
        /// </summary>
        /// <value>
        ///     The repository context.
        /// </value>
        protected IRepositoryContext RepositoryContext
        {
            get { return repositoryContext; }
        }

        /// <summary>
        ///     Gets the current login user.
        /// </summary>
        /// <value>
        ///     The current login user.
        /// </value>
        protected User CurrentLoginUser
        {
            get { return User != null ? ((BasicAuthenticationIdentity)User.Identity).User : null; }
        }

        protected ILog Log
        {
            get { return log; }
        }

        /// <summary>
        ///     Checks if the given aggregate root is exist in the repository.
        /// </summary>
        /// <typeparam name="T">The type of the aggregate root to be checked.</typeparam>
        /// <param name="against">The aggregate root object to be checked.</param>
        /// <param name="repository">The repository for the aggregate root.</param>
        /// <param name="requiresItExists">The checking logic switcher.</param>
        /// <exception cref="Libsys.WebApi.Models.Exceptions.EntityAlreadyExistsException">
        ///     Throws when the <paramref name="requiresItExists" /> is set to <c>false</c> but the aggregate root exists.
        /// </exception>
        /// <exception>
        ///     Throws when the
        ///     <cref>Libsys.WebApi.Models.Exceptions.EntityDoesNotExistException</cref>
        ///     <paramref name="requiresItExists" /> is set to <c>true</c> but the aggregate root does not exist.
        /// </exception>
        protected virtual void RequireExistance<T>(T against, IRepository<T> repository, bool requiresItExists = true)
            where T : class, IAggregateRoot, new()
        {
            RequireExistance(against.ID, repository, requiresItExists);
        }

        /// <summary>
        ///     Checks if the given aggregate root is exist in the repository.
        /// </summary>
        /// <typeparam name="T">The type of the aggregate root.</typeparam>
        /// <param name="id">The identifier of the aggregate root.</param>
        /// <param name="repository">The repository for the aggregate root.</param>
        /// <param name="requiresItExists">The checking logic switcher.</param>
        /// <exception>
        ///     Throws when the
        ///     <cref>Libsys.WebApi.Models.Exceptions.EntityAlreadyExistsException</cref>
        ///     <paramref name="requiresItExists" /> is set to <c>false</c> but the aggregate root exists.
        /// </exception>
        /// <exception>
        ///     Throws when the
        ///     <cref>Libsys.WebApi.Models.Exceptions.EntityDoesNotExistException</cref>
        ///     <paramref name="requiresItExists" /> is set to <c>true</c> but the aggregate root does not exist.
        /// </exception>
        protected virtual void RequireExistance<T>(Guid id, IRepository<T> repository, bool requiresItExists = true)
            where T : class, IAggregateRoot, new()
        {
            RequireExistance(p => p.ID == id, repository, requiresItExists);
        }

        /// <summary>
        ///     Checks if the given aggregate root is exist in the repository.
        /// </summary>
        /// <typeparam name="T">The type of the aggregate root.</typeparam>
        /// <param name="checking">The lambda expression which identifies the checking logic.</param>
        /// <param name="repository">The repository for the aggregate root.</param>
        /// <param name="requiresItExists">The checking logic switcher.</param>
        /// <exception>
        ///     Throws when the
        ///     <cref>Libsys.WebApi.Models.Exceptions.EntityAlreadyExistsException</cref>
        ///     <paramref name="requiresItExists" /> is set to <c>false</c> but the aggregate root exists.
        /// </exception>
        /// <exception>
        ///     Throws when the
        ///     <cref>Libsys.WebApi.Models.Exceptions.EntityDoesNotExistException</cref>
        ///     <paramref name="requiresItExists" /> is set to <c>true</c> but the aggregate root does not exist.
        /// </exception>
        protected virtual void RequireExistance<T>(Expression<Func<T, bool>> checking, IRepository<T> repository,
            bool requiresItExists = true)
            where T : class, IAggregateRoot, new()
        {
            var existance = repository.Exists(Specification<T>.Eval(checking));
            if (!requiresItExists && existance)
            {
                throw new EntityAlreadyExistsException(
                    string.Format(
                        "The aggregate root of type '{0}' already exists in the repository. The checking expression is '{1}'.",
                        typeof(T), checking));
            }
            if (requiresItExists && !existance)
            {
                throw new EntityDoesNotExistException(
                    string.Format(
                        "The aggregate root of type '{0}' does not exist in the repository. The checking expression is '{1}'",
                        typeof(T), checking));
            }
        }

        /// <summary>
        /// Gets the result by criteria.
        /// </summary>
        /// <typeparam name="TAggregateRoot">The type of the aggregate root.</typeparam>
        /// <typeparam name="TViewModel">The type of the dto.</typeparam>
        /// <param name="repository">The repository.</param>
        /// <param name="criteria">The criteria.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">repository</exception>      
        protected virtual IEnumerable<TDto> GetByCriteria<TAggregateRoot, TDto>(
            IRepository<TAggregateRoot> repository,
            QueryCriteria<TAggregateRoot> criteria)
            where TAggregateRoot : class, IAggregateRoot, new()
            where TDto : class, IEntityDto, new()
        {
            if (repository == null)
            {
                throw new ArgumentNullException("repository");
            }

            if (criteria == null)
            {
                return repository.FindAll().ProjectTo<TDto>();
            }

            Specification<TAggregateRoot> querySpecification = new AnySpecification<TAggregateRoot>();
            if (!string.IsNullOrEmpty(criteria.FilterExpression))
            {
                querySpecification =
                    Specification<TAggregateRoot>.Eval(
                        DynamicExpression.ParseLambda<TAggregateRoot, bool>(criteria.FilterExpression));
            }

            if (criteria.PageSize.HasValue && criteria.PageNumber.HasValue)
            {               
                return repository.FindAll(querySpecification, criteria.sortSpecification,
                    criteria.PageNumber.Value, criteria.PageSize.Value)
                    .CastPagedResult<TAggregateRoot, TDto>(Mapper.Map<TAggregateRoot, TDto>);
            }
            return repository
                .FindAll(querySpecification, criteria.sortSpecification)
                .ProjectTo<TDto>();
        }

        /// <summary>
        /// Gets the result by criteria.
        /// </summary>
        /// <typeparam name="TAggregateRoot">The type of the aggregate root.</typeparam>
        /// <typeparam name="TDto">The type of the dto.</typeparam>
        /// <param name="repository">The repository.</param>
        /// <param name="filterExpression">The filter expression.</param>
        /// <param name="sortSpecification">The sorting specification.</param>
        /// <returns></returns>
        protected virtual IEnumerable<TDto> GetByCriteria<TAggregateRoot, TDto>(
            IRepository<TAggregateRoot> repository,
            string filterExpression = null, SortSpecification<TAggregateRoot> sortSpecification = null)
            where TAggregateRoot : class, IAggregateRoot, new()
            where TDto : class, IEntityDto, new()
        {
            if (repository == null)
            {
                throw new ArgumentNullException("repository");
            }

            Specification<TAggregateRoot> querySpecification = new AnySpecification<TAggregateRoot>();
            if (!string.IsNullOrEmpty(filterExpression))
            {
                querySpecification =
                    Specification<TAggregateRoot>.Eval(
                        DynamicExpression.ParseLambda<TAggregateRoot, bool>(filterExpression));
            }
            
            return repository.FindAll(querySpecification, sortSpecification).ProjectTo<TDto>();
        }

        /// <summary>
        /// Gets the paged result by criteria.
        /// </summary>
        /// <typeparam name="TAggregateRoot">The type of the aggregate root.</typeparam>
        /// <typeparam name="TDto">The type of the DTO.</typeparam>
        /// <param name="repository">The repository.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="sortSpecification">The sorting specification.</param>        
        /// <param name="filterExpression">The filter expression.</param>
        /// <param name="expressionArgs">The expression arguments.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">
        ///     repository
        ///     or
        ///     sortingField
        /// </exception>
        protected virtual PagedResultDto<TDto> GetPagedResultByCriteria<TAggregateRoot, TDto>(
            IRepository<TAggregateRoot> repository,
            int pageNumber, int pageSize, SortSpecification<TAggregateRoot> sortSpecification, string filterExpression = null,
            params object[] expressionArgs)
            where TAggregateRoot : class, IAggregateRoot, new()
            where TDto : class, IEntityDto, new()
        {
            if (repository == null)
            {
                throw new ArgumentNullException("repository");
            }
           
            Specification<TAggregateRoot> querySpecification = new AnySpecification<TAggregateRoot>();
            if (!string.IsNullOrEmpty(filterExpression))
            {
                if (expressionArgs != null && expressionArgs.Length > 0)
                {
                    querySpecification =
                        Specification<TAggregateRoot>.Eval(
                            DynamicExpression.ParseLambda<TAggregateRoot, bool>(filterExpression, expressionArgs));
                }
                else
                {
                    querySpecification =
                        Specification<TAggregateRoot>.Eval(
                            DynamicExpression.ParseLambda<TAggregateRoot, bool>(filterExpression));
                }
            }          
            var result = repository.FindAll(querySpecification, sortSpecification, pageNumber, pageSize);
            return result != null
                ? result.CastPagedResult<TAggregateRoot, TDto>(Mapper.Map<TAggregateRoot, TDto>)
                : null;
        }

        /// <summary>
        ///     Releases the unmanaged resources that are used by the object and, optionally, releases the managed resources.
        /// </summary>
        /// <param name="disposing">
        ///     true to release both managed and unmanaged resources; false to release only unmanaged
        ///     resources.
        /// </param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (!disposed)
                {
                    this.repositoryContext.Dispose();
                    disposed = true;
                }
            }
            base.Dispose(disposing);
        }
    }
}