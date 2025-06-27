using NutritionalKitchen.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Test.Domain.Abstractions
{
    public class AggregateRootTest
    {
        [Fact]
        public void Constructor_ShouldSetIdCorrectly()
        {
            // Arrange
            var id = Guid.NewGuid();

            // Act
            var aggregate = new TestAggregateRoot(id);

            // Assert
            Assert.Equal(id, aggregate.Id);
        }
    }
}
