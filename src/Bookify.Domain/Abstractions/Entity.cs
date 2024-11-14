namespace Bookify.Domain.Abstractions;

public abstract class Entity : IDomainEvent
{
    private readonly List<IDomainEvent> _domainEvents = [];

    protected Entity(Guid id)
    {
        Id = id;
    }
    
    public Guid Id { get; init; }
    
    public IReadOnlyCollection<IDomainEvent> GetDomainEvents() => _domainEvents;
    
    public void ClearDomainEvents() => _domainEvents.Clear();
    
    protected void RaiseDomainEvent(IDomainEvent domainEvent) => _domainEvents.Add(domainEvent);
}