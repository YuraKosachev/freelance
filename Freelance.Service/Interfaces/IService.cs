﻿using System;
using System.Collections.Generic;
using Freelance.Service.ServicesModel;


namespace Freelance.Service.Interfaces
{
     public interface IService<TServiceModel>
        where TServiceModel : class
    {
        IFreelanceList<TServiceModel> GetList();
        TServiceModel GetItem(Guid id);
        Guid Create(TServiceModel item);
        void Update(TServiceModel item);
        void Delete(Guid id);
    }
}
