using System.Collections.Generic;

namespace DataPaginator.Models.Abstractions
{
    public interface IPageModel<TModel> where TModel : class
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public IEnumerable<TModel> Items { get; set; }
        public int TotalPages { get; set; }
        public int TotalItems { get; set; }
    }
}