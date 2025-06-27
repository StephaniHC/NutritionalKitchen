using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Test.Domain.Abstractions
{
    public class EntityTest
    {
        [Fact]
        public void Constructor_WithValidId_ShouldSetId()
        {
            // Arrange
            var id = Guid.NewGuid();

            // Act
            var entity = new TestEntity(id);

            // Assert
            Assert.Equal(id, entity.Id);
        }

        [Fact]
        public void Constructor_WithEmptyId_ShouldThrowException()
        {
            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => new TestEntity(Guid.Empty));
            Assert.Equal("Id cannot be empty (Parameter 'id')", ex.Message);
        }

        [Fact]
        public void AddDomainEvent_ShouldAddEventToList()
        {
            var entity = new TestEntity(Guid.NewGuid());
            var domainEvent = new TestDomainEvent("Test");

            entity.AddDomainEvent(domainEvent);

            Assert.Single(entity.DomainEvents);
            Assert.Contains(domainEvent, entity.DomainEvents);
        }

        [Fact]
        public void ClearDomainEvents_ShouldRemoveAllEvents()
        {
            var entity = new TestEntity(Guid.NewGuid());
            entity.AddDomainEvent(new TestDomainEvent("event1"));
            entity.AddDomainEvent(new TestDomainEvent("event2"));

            entity.ClearDomainEvents();

            Assert.Empty(entity.DomainEvents);
        }

    }
}
