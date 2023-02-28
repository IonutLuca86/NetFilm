using System.Linq.Expressions;

namespace NetFilm.Database.Services
{
    public interface IDbService
    {
        Task<TEntity> AddAsync<TEntity, TDto>(TDto dto)
            where TEntity : class
            where TDto : class;
        Task<bool> AnyAsync<TEntity>(Expression<Func<TEntity, bool>> expression) where TEntity : class, IEntity;
        Task<TReferenceEntity> ConnectionAddAsync<TReferenceEntity, TDto>(TDto dto)
            where TReferenceEntity : class
            where TDto : class;
        Task<bool> ConnectionAnyAsync<TReferenceEntity>(Expression<Func<TReferenceEntity, bool>> expression) where TReferenceEntity : class, IReferenceEntity;
        Task<List<TDto>> ConnectionGetAsync<TReferenceEntity, TDto>()
            where TReferenceEntity : class, IReferenceEntity
            where TDto : class;
        Task<TDto> ConnectionSingleAsync<TReferenceEntity, TDto>(Expression<Func<TReferenceEntity, bool>> expression)
            where TReferenceEntity : class, IReferenceEntity
            where TDto : class;
        void ConnectionUpdate<TReferenceEntity, TDto>(int id, TDto dto)
            where TReferenceEntity : class, IEntity
            where TDto : class;
        bool Delete<TReferenceEntity, TDto>(TDto dto)
            where TReferenceEntity : class
            where TDto : class;
        Task<bool> DeleteAsync<TEntity>(int id) where TEntity : class, IEntity;
        Task<List<TDto>> GetAsync<TEntity, TDto>()
            where TEntity : class, IEntity
            where TDto : class;
        void Include<TEntity>() where TEntity : class;
        Task<bool> SaveChangesAsync();
        Task<TDto> SingleAsync<TEntity, TDto>(Expression<Func<TEntity, bool>> expression)
            where TEntity : class, IEntity
            where TDto : class;
        void Update<TEntity, TDto>(int id, TDto dto)
            where TEntity : class, IEntity
            where TDto : class;
    }
}