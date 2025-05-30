﻿using ERP_Store.Domain.Entities;

namespace ERP_Store.Domain.Abstractions;

public interface IBaseRepository<T> where T : BaseEntity
{
    void Create(T entity);
    void Update(T entity);
    void Delete(T entity);

    Task<T> Get(int id, CancellationToken cancellationToken);
    Task<List<T>> GetAll(CancellationToken cancellationToken);
}