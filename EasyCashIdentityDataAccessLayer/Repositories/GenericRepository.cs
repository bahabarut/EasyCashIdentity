﻿using EasyCashIdentityDataAccessLayer.Abstract;
using EasyCashIdentityDataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashIdentityDataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        public void Delete(T t)
        {
            using Context context = new Context();
            context.Set<T>().Remove(t);
            context.SaveChanges();
        }

        public T GetById(int id)
        {
            using Context context = new Context();
            return context.Set<T>().Find(id);
        }

        public List<T> GetList()
        {
            using Context context = new Context();
            return context.Set<T>().ToList();
        }

        public void Insert(T t)
        {
            using Context context = new Context();
            context.Set<T>().Add(t);
            context.SaveChanges();
        }

        public void Update(T t)
        {
            using Context context = new Context();
            context.Set<T>().Update(t);
            context.SaveChanges();
        }
    }
}
