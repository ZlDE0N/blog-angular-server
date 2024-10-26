using System.Collections.Generic;
using System.Threading.Tasks;
using BackendBlogServicesApi.Entity;

namespace BackendBlogServicesApi.Repositories.Interfaces
{
    public interface IEntriesBlogRepository
    {
        Task<EntriesBlog> GetByIdAsync(int id);
        Task<IEnumerable<EntriesBlog>> GetAllAsync();
        Task AddAsync(EntriesBlog entry);
        Task UpdateAsync(EntriesBlog entry);
        Task DeleteAsync(int id);
        Task<bool> ExistsByTitleAsync(string title, int? excludeId = null);
    }
}
