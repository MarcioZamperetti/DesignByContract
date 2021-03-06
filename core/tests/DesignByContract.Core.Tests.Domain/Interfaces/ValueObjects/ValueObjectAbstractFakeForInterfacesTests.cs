﻿using DesignByContract.Core.Domain.Errors;
using DesignByContract.Core.Domain.Interfaces.ValueObjects;
using NUnit.Framework;

namespace DesignByContract.Core.Tests.Domain.Interfaces.ValueObjects
{
    [TestFixture]
    public abstract class ValueObjectAbstractFakeForInterfacesTests
    {
        public abstract IValueObject GetValueObjectInstance();

        [Test]
        public void ValueObjectErrorListAddReturnAnyTrue()
        {
            var entity = GetValueObjectInstance();
            var errorList = entity.ErrorList;
            errorList.Add(new ErrorItemDetail("Test", new Critical(), ""));
            Assert.IsTrue(errorList.Any);
        }

        [Test]
        public void ValueObjectValidSpecificationReturnSpecificarion()
        {
            var entity = GetValueObjectInstance();
            var validation = entity.ValidSpecification;
            Assert.IsTrue(validation != null);
        }

        [Test]
        public void ValueObjectFieldNameReturnClassName()
        {
            var entity = GetValueObjectInstance();
            Assert.IsTrue(entity.FieldName == "ValueObjectFakeForInterfaces");
        }
    }
}