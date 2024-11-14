using Bookify.Domain.Apartments;

namespace Bookify.Infrastructure.Repositories;

internal sealed class ApartmentRepository(BookifyDbContext dbContext) 
    : Repository<Apartment>(dbContext), IApartmentRepository
{
    
}