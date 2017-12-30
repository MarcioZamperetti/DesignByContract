﻿using DesignByContract.Domain.Core.Interfaces.Errors;

namespace DesignByContract.Domain.Core.Tests.DomainCoreFake.Errors
{
    public class LevelFakeForInterfaces : ILevel
    {
        public LevelFakeForInterfaces(string description)
        {
            Description = description;
        }

        public string Description { get; }

        public override string ToString() => Description;
    }
}