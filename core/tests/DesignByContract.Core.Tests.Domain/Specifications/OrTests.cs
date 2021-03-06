﻿using DesignByContract.Core.Domain.Interfaces.Specifications;
using DesignByContract.Core.Domain.Specifications;
using DesignByContract.Core.Tests.Domain.Mocks.DomainFake.Entities;
using NUnit.Framework;

namespace DesignByContract.Core.Tests.Domain.Specifications
{
    [TestFixture]
    public class OrTests
    {
        [Test]
        public void OrWhenFilterWithTwoSpecificationsReturnTrue()
        {
            ISpecification<EntityFakeForSpecification> isCustomer = new Expression<EntityFakeForSpecification>(x => x.Category == "Customer");
            ISpecification<EntityFakeForSpecification> livesInNewYork = new Expression<EntityFakeForSpecification>(x => x.City == "New York");
            var sut = isCustomer.Or(livesInNewYork);
            Assert.IsTrue(sut.IsSatisfiedBy(new EntityFakeForSpecification { Category = "Customer", City = "New York" }));
        }

        [Test]
        public void OrWhenFilterWithTwoSpecificationsReturnFalse()
        {
            ISpecification<EntityFakeForSpecification> isCustomer = new Expression<EntityFakeForSpecification>(x => x.Category == "Customer");
            ISpecification<EntityFakeForSpecification> livesInNewYork = new Expression<EntityFakeForSpecification>(x => x.City == "New York");
            var sut = isCustomer.Or(livesInNewYork);
            Assert.IsFalse(sut.IsSatisfiedBy(new EntityFakeForSpecification { Category = "Partner", City = "Rio" }));
        }

        [Test]
        public void OrWhenFilterWithManySpecificationsReturnTrue()
        {
            ISpecification<EntityFakeForSpecification> isCustomer = new Expression<EntityFakeForSpecification>(x => x.Category == "Customer");
            ISpecification<EntityFakeForSpecification> livesInNewYork = new Expression<EntityFakeForSpecification>(x => x.City == "New York");
            ISpecification<EntityFakeForSpecification> isActive = new Expression<EntityFakeForSpecification>(x => x.Active);
            var sut = isCustomer.Or(livesInNewYork)
                                .Or(isActive);
            Assert.IsTrue(sut.IsSatisfiedBy(new EntityFakeForSpecification { Category = "Customer", City = "New York", Active = true }));
        }

        [Test]
        public void OrWhenFilterWithManySpecificationsReturnFalse()
        {
            ISpecification<EntityFakeForSpecification> isCustomer = new Expression<EntityFakeForSpecification>(x => x.Category == "Customer");
            ISpecification<EntityFakeForSpecification> livesInNewYork = new Expression<EntityFakeForSpecification>(x => x.City == "New York");
            ISpecification<EntityFakeForSpecification> isActive = new Expression<EntityFakeForSpecification>(x => x.Active);
            var sut = isCustomer.Or(livesInNewYork)
                                .Or(isActive);
            Assert.IsFalse(sut.IsSatisfiedBy(new EntityFakeForSpecification { Category = "Partner", City = "Rio", Active = false }));
        }
    }
}