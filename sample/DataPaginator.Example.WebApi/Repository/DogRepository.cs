using DataPaginator.EntityFrameworkCore.Extensions;
using DataPaginator.Example.WebApi.Models;
using DataPaginator.Models.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace DataPaginator.Example.WebApi.Repository
{
    public class DogRepository : IDogRepository
    {
        private readonly Data.DataContext _dogContext;
        public DogRepository(Data.DataContext dogContext)
        {
            _dogContext = dogContext;
        }
        public async Task<IEnumerable<Dog>> GetDogs()
        {
            var dogs = await _dogContext.Dogs.ToListAsync();
            return dogs;
        }

        public async Task<IPageModel<Dog>> GetPaginatedDogs(int pageNumber, int pageSize)
        {
            var dogs = await _dogContext.Dogs.AsNoTracking().OrderBy(d => d.Id).PaginateAsync(pageNumber, pageSize);
            return dogs;
        }
    }
}
