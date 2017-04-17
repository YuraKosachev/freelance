using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freelance.FileManagerProvider.Interfaces
{
    public interface IFileProvider
    {
        void SetPath(string path);
        Guid Create(string content, string userId);
        string GetFile(Guid fileId, string userId);
        void Delete(Guid FileId, string userId);
    }
}
