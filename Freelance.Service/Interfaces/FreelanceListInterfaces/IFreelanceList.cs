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
        void Filter(string predicate, params object[] values);
        void FilterAnd(string predicate, params object[] values);
        void FilterOr(string predicate, params object[] values);
      

        IEnumerable<TModel> List();
       
    }
}
