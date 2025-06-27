using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Test.Domain.Abstractions
{
    public class DomainEventTest
    {
        [Fact]
        public void Constructor_ShouldInitializeIdAndOccuredOn()
        {
            // Act
            var testEvent = new TestDomainEvent("Test event");

            // Assert
            Assert.NotEqual(Guid.Empty, testEvent.Id);
            Assert.True((DateTime.Now - testEvent.OccuredOn).TotalSeconds < 5);
        }

        [Fact]
        public void Message_ShouldBeAssignedCorrectly()
        {
            // Arrange
            var message = "Hello Event";

            // Act
            var testEvent = new TestDomainEvent(message);

            // Assert
            Assert.Equal(message, testEvent.Message);
        }
    }
}
