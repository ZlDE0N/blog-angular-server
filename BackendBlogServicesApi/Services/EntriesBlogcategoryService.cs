using BackendBlogServicesApi.Data;
using BackendBlogServicesApi.DTOs;
using BackendBlogServicesApi.Entity;
using BackendBlogServicesApi.Repositories;

namespace BackendBlogServicesApi.Services
{
    public class EntriesBlogCategoryService
    {
        private readonly IEntriesBlogCategoryRepository _repository;

        public EntriesBlogCategoryService(IEntriesBlogCategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<EntriesBlogCategoryDto>> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null || entity.Category == null || entity.EntriesBlog == null)
            {
                return Result<EntriesBlogCategoryDto>.Failure(new EntriesBlogCategoryDto(), "Entry not found.");
            }

            var dto = new EntriesBlogCategoryDto
            {
                IdEntriesBlog = entity.IdEntriesBlog,
                IdCategories = entity.IdCategories,
                CategoriaName = entity.Category.Name,
                Title = entity.EntriesBlog.Title,
                Content = entity.EntriesBlog.Content,
                Author = entity.EntriesBlog.Author,
                PublicationDate = entity.EntriesBlog.PublicationDate
            };

            return Result<EntriesBlogCategoryDto>.Success(dto);
        }

        public async Task<Result<IEnumerable<EntriesBlogCategoryDto>>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            var dtos = entities.Select(entity => new EntriesBlogCategoryDto
            {
                IdEntriesBlog = entity.IdEntriesBlog,
                IdCategories = entity.IdCategories,
                CategoriaName = entity.Category.Name,
                Title = entity.EntriesBlog.Title,
                Content = entity.EntriesBlog.Content,
                Author = entity.EntriesBlog.Author,
                PublicationDate = entity.EntriesBlog.PublicationDate
            }).ToList();

            return Result<IEnumerable<EntriesBlogCategoryDto>>.Success(dtos);
        }


        public async Task<Result<EntriesBlogCategoryDto>> AddAsync(CreateEntriesBlogCategoryDto dto)
        {
            var entity = new EntriesBlogCategory
            {
                IdEntriesBlog = dto.IdEntriesBlog,
                IdCategories = dto.IdCategories,
                Estado = true
            };

            await _repository.AddAsync(entity);
            return Result<EntriesBlogCategoryDto>.Success(new EntriesBlogCategoryDto
            {
                IdEntriesBlog = entity.IdEntriesBlog,
                IdCategories = entity.IdCategories,
                CategoriaName = entity.Category.Name,
                Title = entity.EntriesBlog.Title,
                Content = entity.EntriesBlog.Content,
                Author = entity.EntriesBlog.Author,
                PublicationDate = entity.EntriesBlog.PublicationDate
            });
        }

        public async Task<Result<bool>> UpdateAsync(int id, CreateEntriesBlogCategoryDto dto)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
            {
                return Result<bool>.Failure(false, "Entity fallo.");
            }

            entity.IdEntriesBlog = dto.IdEntriesBlog;
            entity.IdCategories = dto.IdCategories;
            entity.UpdatedAt = DateTime.Now;

            await _repository.UpdateAsync(entity);
            return Result<bool>.Success(true, "");
        }

        public async Task<Result<bool>> DeleteAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
            {
                return Result<bool>.Failure(false, "Entity fallo.");
            }

            await _repository.DeleteAsync(id);
            return Result<bool>.Success(true, "Se ha Eliminado la Relacion Categorian Entrada blogs");
        }
    }
}
