using Bookify.Domain.Users;

namespace Bookify.Infrastructure.Repositories;

internal sealed class UserRepository(BookifyDbContext dbContext) 
    : Repository<User>(dbContext), IUserRepository
{
    
}