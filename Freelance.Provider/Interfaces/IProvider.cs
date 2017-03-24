﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Freelance.Extensions.Interfaces;

namespace Freelance.Provider.Interfaces
{
   public interface IProvider<TModel>
        where TModel :class
    {
        IAppQuery<TModel> GetList();
        TModel GetItem(Guid id);
        void Create(TModel item);
        void Update(TModel item);
        void Delete(Guid id);
    }
}
