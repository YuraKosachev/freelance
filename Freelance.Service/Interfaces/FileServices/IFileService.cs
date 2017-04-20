using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freelance.Service.Interfaces
{
    public interface IFileService
    {
        Guid Create(string content, string userId);
        string Create(string content, string folderName, string fileExtension);
        string GetFile(Guid fileId, string userId);
        void Delete(Guid fileId, string userId);
    }
}
