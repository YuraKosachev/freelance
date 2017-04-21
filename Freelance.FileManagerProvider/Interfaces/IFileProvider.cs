using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freelance.FileManagerProvider.Interfaces
{
    public interface IFileProvider
    {
        //string Create(string base64Content, string folderName);
        string Create(byte[] content, string fileExtension, Func<string, string> pathGenerator);
        string GetFile(Guid fileId, string userId);
        void Delete(Guid FileId, string userId);
    }
}
