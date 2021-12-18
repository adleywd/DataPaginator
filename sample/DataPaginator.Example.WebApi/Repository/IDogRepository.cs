using DataPaginator.Example.WebApi.Models;
using DataPaginator.Models.Abstractions;

namespace DataPaginator.Example.WebApi.Repository
{
    public interface IDogRepository
    {
        public Task<IEnumerable<Dog>> GetDogs();
        public Task<IPageModel<Dog>> GetPaginatedDogs(int pageNumber, int pageSize);
    }
}
