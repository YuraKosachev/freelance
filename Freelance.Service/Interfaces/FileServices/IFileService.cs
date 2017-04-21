using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freelance.Service.Interfaces
{
    public interface IFileService
    {
        string Create(string base64Content, string userId, Func<string,byte[]> convert);
        string Create(byte[] content, string userId, string fileExtension);
        string GetFile(Guid fileId, string userId);
        void Delete(Guid fileId, string userId);
    }
}
