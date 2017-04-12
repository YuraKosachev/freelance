using System;
using System.Collections.Generic;
using System.Linq;
using Freelance.Service.Interfaces;
using Freelance.Extensions.Interfaces;
using AutoMapper;

namespace Freelance.Service.ServicesModel
{
    public class FreelanceList<TModel, TEntity> : IFreelanceList<TModel>
    {
        private IAppQuery<TEntity> ProviderList { get; set; }
        public FreelanceList(IAppQuery<TEntity> providerList)
        {
            ProviderList = providerList;
        }
        public void Filter()
        {
            throw new NotImplementedException();
        }

        public int ItemCount()
        {
            return ProviderList.CountItem();
        }

        public IEnumerable<TModel> List()
        {
            return ProviderList.Select(item => Mapper.Map<TModel>(item));
        }

        public void SortPage(string property, bool ascending)
        {
            ProviderList.SetSortOptions(property, ascending);
        }

        public void TakePage(int current, int size)
        {
            ProviderList.SetPageOptions(current, size);
        }

        public void Filter<TType>(string property, TType value)
        {
            ProviderList.SetFilterOptions(property,value);
        }

        public void FilterXor<TType>(string property, TType value)
        {
            ProviderList.FilterXor(property, value);
        }

        public void FilterAndXor<TType>(string property, TType value)
        {
            ProviderList.FilterAndXor(property, value);
        }

        public void FilterOrXor<TType>(string property, TType value)
        {
            ProviderList.FilterOrXor(property, value); 
        }

        public void FilterAnd<TType>(string property, TType value)
        {
            ProviderList.FilterAnd(property, value); 
        }

        public void FilterOr<TType>(string property, TType value)
        {
            ProviderList.FilterOr(property, value); 
        }
        public void FilterString(string query)
        {
            ProviderList.FilterString(query);
        }
    }
}
