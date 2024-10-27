using BackendBlogServicesApi.Data;
using BackendBlogServicesApi.DTOs;
using BackendBlogServicesApi.Entity;
using Microsoft.EntityFrameworkCore;

namespace BackendBlogServicesApi.Repositories
{
    public class EntriesBlogCategoryRepository : IEntriesBlogCategoryRepository
    {
        private readonly AppDbContext _context;

        public EntriesBlogCategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<EntriesBlogCategory> GetByIdAsync(int id)
        {
            return await _context.Set<EntriesBlogCategory>()
                .Include(e => e.Category)
                .Include(e => e.EntriesBlog)
                .FirstOrDefaultAsync(e => e.Id == id);

        }

        public async Task<IEnumerable<EntriesBlogCategory>> GetAllAsync()
        {
            return await _context.Set<EntriesBlogCategory>()
                .Include(e => e.Category)
                .Include(e => e.EntriesBlog)
                .ToListAsync(); // Devuelve la lista de entidades.
        }

        public async Task AddAsync(EntriesBlogCategory entriesBlogCategory)
        {
            await _context.Set<EntriesBlogCategory>().AddAsync(entriesBlogCategory);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(EntriesBlogCategory entriesBlogCategory)
        {
            _context.Set<EntriesBlogCategory>().Update(entriesBlogCategory);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Set<EntriesBlogCategory>().FindAsync(id);
            if (entity != null)
            {
                entity.UpdatedAt = DateTime.Now;
                entity.Estado = false;
                _context.Set<EntriesBlogCategory>().Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
