﻿
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace OngProject.Repositories
{
    public class QueryProperty<T> where T : Entities.Entity
    {
        public QueryProperty(int page, int pageCount)
        {
            Skip = (page - 1) * pageCount;
            Take = pageCount;
        }

        public int Skip { get; set; }
        public int Take { get; set; }
        public Expression<Func<T,bool>> Where { get; set; }
        public List<Expression<Func<T, object>>> Includes { get; set; } = new List<Expression<Func<T, object>>>();
        public Expression<Func<T, object>> OrderBy { get; set; }
        public bool Decending { get; set; }
    }
}