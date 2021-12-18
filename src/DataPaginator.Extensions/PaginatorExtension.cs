using DataPaginator.Models;
using DataPaginator.Models.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace DataPaginator.EntityFrameworkCore.Extensions
{
    public static class PaginatorExtension
    {
        /// <summary>
        /// Returns a paginated model
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="query"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <param name="paged"></param>
        /// <returns></returns>
        public static async Task<IPageModel<TModel>> PaginateAsync<TModel>(
           this IQueryable<TModel> query,
           int pageNumber,
           int pageSize,
           IPageModel<TModel> paged)
           where TModel : class
        {
            paged.CurrentPage = pageNumber;
            paged.PageSize = pageSize;

            var startRow = (paged.CurrentPage - 1) * paged.PageSize;

            paged.Items = await query
                       .Skip(startRow)
                       .Take(paged.PageSize)
                       .ToListAsync()
                       .ConfigureAwait(false);

            paged.TotalItems = await query.CountAsync().ConfigureAwait(false);

            paged.TotalPages = (int)Math.Ceiling(paged.TotalItems / (double)paged.PageSize);

            return paged;
        }
        
        /// <summary>
        /// Returns a paginated model
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="query"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <param name="paged"></param>
        /// <returns></returns>
        public static async Task<IPageModel<TModel>> PaginateAsync<TModel>(
           this IQueryable<TModel> query,
           int pageNumber,
           int pageSize,
           IPageModel<TModel> paged,
           CancellationToken cancellationToken)
           where TModel : class
        {
            paged.CurrentPage = pageNumber;
            paged.PageSize = pageSize;

            var startRow = (paged.CurrentPage - 1) * paged.PageSize;

            paged.Items = await query
                       .Skip(startRow)
                       .Take(paged.PageSize)
                       .ToListAsync(cancellationToken)
                       .ConfigureAwait(false);

            paged.TotalItems = await query.CountAsync(cancellationToken).ConfigureAwait(false);

            paged.TotalPages = (int)Math.Ceiling(paged.TotalItems / (double)paged.PageSize);

            return paged;
        }

        /// <summary>
        /// Returns a paginated model
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="query"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static async Task<IPageModel<TModel>> PaginateAsync<TModel>(
           this IQueryable<TModel> query,
           int pageNumber,
           int pageSize)
           where TModel : class
        {
            var paged = new PageModel<TModel>
            {
                CurrentPage = pageNumber,
                PageSize = pageSize
            };

            var startRow = (paged.CurrentPage - 1) * paged.PageSize;

            paged.Items = await query
                       .Skip(startRow)
                       .Take(paged.PageSize)
                       .ToListAsync()
                       .ConfigureAwait(false);

            paged.TotalItems = await query.CountAsync().ConfigureAwait(false);

            paged.TotalPages = (int)Math.Ceiling(paged.TotalItems / (double)paged.PageSize);

            return paged;
        }

        /// <summary>
        /// Returns a paginated model
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="query"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<IPageModel<TModel>> PaginateAsync<TModel>(
           this IQueryable<TModel> query,
           int pageNumber,
           int pageSize,
           CancellationToken cancellationToken)
           where TModel : class
        {
            var paged = new PageModel<TModel>
            {
                CurrentPage = pageNumber,
                PageSize = pageSize
            };

            var startRow = (paged.CurrentPage - 1) * paged.PageSize;

            paged.Items = await query
                       .Skip(startRow)
                       .Take(paged.PageSize)
                       .ToListAsync(cancellationToken)
                       .ConfigureAwait(false);

            paged.TotalItems = await query.CountAsync().ConfigureAwait(false);

            paged.TotalPages = (int)Math.Ceiling(paged.TotalItems / (double)paged.PageSize);

            return paged;
        }
    }
}