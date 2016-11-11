using Apstars.Application.Dto;
using Apstars.Querying;
using Apstars.Repositories;
using Libsys.Domain.Model;
using Libsys.WebApi.AutoMapper;
using Libsys.WebApi.Dtos;
using Libsys.WebApi.Models.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Libsys.WebApi.Controllers
{
    /// <summary>
    /// Represents the controller that provides Books APIs.
    /// </summary>
    [WebApiLogging]
    public class BooksController : WebApiController
    {
        #region Private Fields

        private readonly IRepository<Book> bookRepository;

        #endregion

        #region Ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="BooksController" /> class.
        /// </summary>
        /// <param name="repositoryContext">The repository context.</param>
        /// <param name="bookRepository">The book repository.</param>
        public BooksController(IRepositoryContext repositoryContext, IRepository<Book> bookRepository)
            : base(repositoryContext)
        {
            this.bookRepository = bookRepository;
        }

        #endregion

        #region Public APIs
        /// <summary>
        /// 获取书籍
        /// </summary>
        /// <param name="id">书籍id</param>
        /// <returns>一本书</returns>
        public BookDto4R GetBookByID(Guid id)
        {
            RequireExistance(n => n.ID == id, bookRepository);

            var book = bookRepository.GetByKey(id);

            return book.MapTo<BookDto4R>();
        }

        [Route("books/list/{pageNumber:int:min(1)=1}/{pageSize:int=25}")]
        public PagedResultDto<BookDto4R> GetBookList(int pageNumber, int pageSize)
        {
            var sortSpecification = new SortSpecification<Book>();
            sortSpecification.Add(b => b.UnitPrice, SortOrder.Descending);
            sortSpecification.Add(b => b.PublishDate, SortOrder.Ascending);

            return GetPagedResultByCriteria<Book, BookDto4R>(bookRepository,
                pageNumber,
                pageSize,
                sortSpecification);
        }
        #endregion
    }
}
