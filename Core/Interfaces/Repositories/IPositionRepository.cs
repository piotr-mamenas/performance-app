﻿namespace Core.Interfaces.Repositories
{
    public interface IPositionRepository<TSpecificEntity> : IRepository<TSpecificEntity> where TSpecificEntity : class, IEntityRoot, new()
    {
    }
}