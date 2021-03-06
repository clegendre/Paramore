﻿using System;

namespace Paramore.Infrastructure.Repositories
{
    public interface IRepository<T, TDocument> where T: IAmAnAggregateRoot<TDocument> where TDocument : IAmADocument
    {
        void Add(T aggregate);
        T this[Guid id] { get; }
        IUnitOfWork UnitOfWork { set; }
    }
}
