using Bookify.Domain.Abstractions;

namespace Bookify.Infrastructure.Repositories;

internal abstract class Repository<T>(
    BookifyDbContext dbContext) where T : Entity
{
    public async Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await dbContext.Set<T>()
            .FindAsync([id], cancellationToken: cancellationToken);   
    }

    public void Add(T entity)
    {
        dbContext.Set<T>().Add(entity);
    }
}