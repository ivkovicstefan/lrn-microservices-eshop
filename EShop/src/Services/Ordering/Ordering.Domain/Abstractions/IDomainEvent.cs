using MediatR;

namespace Ordering.Domain.Abstractions
{
    public interface IDomainEvent : INotification
    {
        Guid EventId => Guid.NewGuid();
        public string OccuredOn => GetType().AssemblyQualifiedName;
    }
}
