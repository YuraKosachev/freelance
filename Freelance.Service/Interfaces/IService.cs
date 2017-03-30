using System;
using System.Collections.Generic;


namespace Freelance.Service.Interfaces
{
     public interface IService<TServiceModel>
        where TServiceModel : class
    {
        IEnumerable<TServiceModel> GetList();
        TServiceModel GetItem(Guid id);
        void Create(TServiceModel item);
        void Update(TServiceModel item);
        void Delete(Guid id);
    }
}
