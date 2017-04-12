using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freelance.Service.Interfaces
{
    public interface IFreelanceList<TModel>
    {
        int ItemCount();
        
        void SortPage(string property, bool ascending);
        void TakePage(int current, int size);
        //Filtring
        void Filter<TType>(string property, TType value);
        void FilterXor<TType>(string property, TType value);
        void FilterAndXor<TType>(string property, TType value);
        void FilterOrXor<TType>(string property, TType value);
        void FilterAnd<TType>(string property, TType value);
        void FilterOr<TType>(string property, TType value);
        void FilterString(string query);

        IEnumerable<TModel> List();
       
    }
}
