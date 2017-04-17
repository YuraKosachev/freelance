using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Freelance.FileManagerProvider.Interfaces;
using System.IO;

namespace Freelance.FileManagerProvider.Repositories
{
    public class AdminRepositoryPath : IRepositoryPath
    {
        public string RepositoryPath()
        {
            return "app";
        }
    }
    public class PhotoRepositoryPath : IRepositoryPath
    {
        public string RepositoryPath()
        {
            return "photos";
        }
    }
    public class FilesRepositoryPath : IRepositoryPath
    {
        public string RepositoryPath()
        {
            return "textfiles";
        }
    }
}
