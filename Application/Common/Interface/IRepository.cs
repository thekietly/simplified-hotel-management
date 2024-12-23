﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interface
{
    // An interface that defines the basic CRUD operations
    public interface IRepository<T> where T : class
    {
        // Retrieve all records from the database + all relevant tables
        Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>>? filter = null,
            Func<IQueryable<T>, IQueryable<T>>? include = null,
            bool tracked = true);
        // Retrieve a single record from the database - this does not include nested related tables
        Task<T> Get(Expression<Func<T, bool>>? filter = null,
            Func<IQueryable<T>, IQueryable<T>>? include = null,
            bool tracked = true);
        // Return true if any record exists in the database that satisfies the given filter
        bool Any(Expression<Func<T, bool>> filter, string? includeProperties = null);
        // Add a new record to the database
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        // Update an existing record in the database
        void Update(T entity);
        // Remove a record from the database
        void Remove(T entity);


    }
}
