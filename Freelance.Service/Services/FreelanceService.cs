using System;
using System.Collections.Generic;
using System.Linq;
using Freelance.Service.Interfaces;
using Freelance.Provider.Interfaces;
using AutoMapper;
using Microsoft.Practices.Unity;
namespace Freelance.Service.Services
{
    public abstract class FreelanceService<TModelService,TProviderModel> : IService<TModelService>
        where TModelService : class
        where TProviderModel : class
    {
        protected IProvider<TProviderModel> Provider { get; set; }
        public FreelanceService()
        {

        }
        public FreelanceService(IProvider<TProviderModel> provider)
        {
            Provider = provider;

        }
        public virtual void Create(TModelService item)
        {
            Provider.Create(Mapper.Map<TProviderModel>(item));
        }

        public virtual void Delete(Guid id)
        {
            Provider.Delete(id);
        }

        public virtual TModelService GetItem(Guid id)
        {
            return Mapper.Map<TModelService>(Provider.GetItem(id));
        }

        public virtual IEnumerable<TModelService> GetList()
        {
            return Provider.GetList().Select(item => Mapper.Map<TModelService>(item));
        }

        public virtual void Update(TModelService item)
        {
            Provider.Update(Mapper.Map<TProviderModel>(item));
        }
    }
}
