﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace marketplace3.DataAccessLayer.Pagination
{
    public class PagedList<T> : List<T>
    {
        public int CurrentPage { get; private set; }

        public int TotalPages { get; private set; }

        public int PageSize { get; private set; }

        public int TotalEntitiesCount { get; private set; }

        public bool HasPrevious => CurrentPage > 1;

        public bool HasNext => CurrentPage < TotalPages;

        public object Metadata => new
        {
            CurrentPage,
            TotalPages,
            PageSize,
            TotalEntitiesCount,
            HasPrevious,
            HasNext
        };

        public PagedList<TOut> Map<TOut>(Func<T, TOut> selectExpression)
        {
            var mappedItems = this.Select(selectExpression);
            return new PagedList<TOut>(
                mappedItems,
                TotalEntitiesCount,
                CurrentPage,
                PageSize);
        }

        
        public static async Task<PagedList<T>> ToPagedListAsync(
            IQueryable<T> source,
            int pageNumber,
            int pageSize)
        {
            int totalEntitiesCount = await source.CountAsync();

            IEnumerable<T> items = await source
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PagedList<T>(items, totalEntitiesCount, pageNumber, pageSize);
        }

        
        public PagedList(
            IEnumerable<T> items,
            int totalEntitiesCount,
            int pageNumber,
            int pageSize)
        {
            CurrentPage = pageNumber;
            PageSize = pageSize;
            TotalEntitiesCount = totalEntitiesCount;
            TotalPages = (int)Math.Ceiling(totalEntitiesCount / (double)pageSize);

            AddRange(items);
        }
    }
}
