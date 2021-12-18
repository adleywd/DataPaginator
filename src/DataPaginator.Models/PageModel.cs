using DataPaginator.Models.Abstractions;

namespace DataPaginator.Models
{
    public class PageModel<TModel> : IPageModel<TModel> where TModel : class
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int TotalItems { get; set; }
        public IEnumerable<TModel> Items { get; set; } = Enumerable.Empty<TModel>();
    }
}
