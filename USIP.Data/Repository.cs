using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using USIP.Data.Context;

namespace USIP.Data
{
	public class Repository<T> : IDisposable where T : class, new()
	{
		public BaseContext Context { get; set; }

		public Repository(BaseContext context)
		{
			Context = context;
		}

		public void Dispose()
		{
			if (Context != null)
			{
				Context.Dispose();
			}
		}

		public T Insert(T entity)
		{
			var entry = Context.Set<T>().Add(entity);
			Context.SaveChanges();
			return entry;
		}

		public int Update(T entity)
		{
			var entry = Context.Entry(entity);
			Context.Set<T>().Attach(entity);
			entry.State = EntityState.Modified;
			return Context.SaveChanges();
		}

		public bool Delete(Expression<Func<T, bool>> lambda)
		{
			var matches = Select(lambda);
			if (matches == null)
			{
				return false;
			}

			foreach (T match in matches)
			{
				Context.Set<T>().Remove(match);
			}
			Context.SaveChanges();
			return true;
		}

		public IQueryable<T> Select(Expression<Func<T, bool>> lambda)
		{
			lambda.Compile();
			return Context
				.Set<T>()
				.Where(lambda)
				.AsQueryable();
		}
	}
}
