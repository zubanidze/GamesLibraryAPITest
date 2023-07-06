using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Security.Principal;

namespace GamesLibrary.Infrastructure.Db.Repositories.Abstractions
{
    public interface IBaseRepository<TEntity, in TId>
     where TEntity : EntityBase<TId>
     where TId : IEquatable<TId>
    {
        Task<long> Count();

        Task<IEnumerable<TEntity>> FindIncludingBy(
            Expression<Func<TEntity, bool>> predicate,
            params Expression<Func<TEntity, object>>[] includeProperties);



        Task<IEnumerable<TEntity>> All();

        Task<TEntity> GetSingle(TId id, IEnumerable<string> include = null);

        void Add(TEntity entity);
        void Update(TEntity entity);
        void PartialUpdate(TEntity entity, IEnumerable<string> properties);

        Task<TEntity> GetFirstOrDefault(
            Expression<Func<TEntity, bool>> predicate,
            params Expression<Func<TEntity, object>>[] includeProperties);

        Task CommitAsync();
        void Delete(TId id);
        void DeleteWhere(Expression<Func<TEntity, bool>> predicate);

    }
    public interface IEntity
    {
        // empty
    }
    public class EntityBase<TId> : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public virtual TId Id { get; set; }
    }
}
