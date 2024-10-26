using BackendBlogServicesApi.DTOs;
using BackendBlogServicesApi.Entity;

namespace BackendBlogServicesApi.Repositories
{
    public interface IEntriesBlogCategoryRepository
    {
        Task<EntriesBlogCategory> GetByIdAsync(int id);
        Task<IEnumerable<EntriesBlogCategory>> GetAllAsync();
        Task AddAsync(EntriesBlogCategory entriesBlogCategory);
        Task UpdateAsync(EntriesBlogCategory entriesBlogCategory);
        Task DeleteAsync(int id);
    }
}
