using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Freelance.FileManagerProvider.Repositories;
using Freelance.FileManagerProvider.Interfaces;

namespace Freelance.FileManagerProvider.RepositoryProviders
{
    public class AdminRepositoryProvider:FileProvider<AdminRepositoryPath>,IAdminProvider
    {
        public AdminRepositoryProvider() : base() { }
    }
}
