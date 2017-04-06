using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
