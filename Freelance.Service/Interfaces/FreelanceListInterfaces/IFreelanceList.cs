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
        void Filter();
        void SortPage(string property, bool ascending);
        void TakePage(int current, int size);

        IEnumerable<TModel> List();
       
    }
}
