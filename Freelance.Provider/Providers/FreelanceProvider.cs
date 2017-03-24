using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Freelance.Provider.Interfaces;
using Freelance.Provider.Context;
using System.Data.Entity;
using Freelance.Extensions;
using Freelance.Provider.EntityModels;
namespace Freelance.Provider.Providers
{
    public abstract class FreelanceProvider<TModel> : IProvider<TModel>, IDisposable
        where TModel :class,IModel
    {
        private FreelanceDbContext Context { get; set; }
        public FreelanceProvider()
        {
            Context = new FreelanceDbContext();
        }
        public virtual void Create(TModel item)
        {
            item.Id = Guid.NewGuid();
            Context.Set<TModel>().Add(item);
            Context.SaveChanges();
        }

        public virtual void Delete(Guid id)
        {
            var item = Context.Set<TModel>().Find(id);
            if (item != null)
                Context.Set<TModel>().Remove(item);
            Context.SaveChanges();
        }

        public TModel GetItem(Guid id)
        {
            return Context.Set<TModel>().Find(id);
        }

        public virtual Extensions.Interfaces.IAppQuery<TModel> GetList()
        {
            return new AppQuery<TModel>(Context.Set<TModel>());
        }

        public virtual void Update(TModel item)
        {
            Context.Entry<TModel>(item).State = EntityState.Modified;
            Context.SaveChanges();
        }
        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
