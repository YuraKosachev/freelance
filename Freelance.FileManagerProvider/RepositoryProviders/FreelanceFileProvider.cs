using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Freelance.FileManagerProvider.Interfaces;
using System.IO;

namespace Freelance.FileManagerProvider.RepositoryProviders
{
    public abstract class FreelanceFileProvider : IFileProvider
    {
        public string Create(byte[] content, string extension,Func<string,string> pathGenerator)
        {
            var fileName = FileName(Guid.NewGuid(), extension);
            using (FileStream stream = new FileStream(pathGenerator(fileName), FileMode.Create))
            {
                stream.Write(content, 0, content.Length);
            }
            return fileName;
        }

        public void Delete(Guid FileId, string userId)
        {
            throw new NotImplementedException();
        }

        public string GetFile(Guid fileId, string userId)
        {
            throw new NotImplementedException();
        }
        protected string FileName<TType>(TType name, string extension)
        {
            return String.Format("{0}.{1}", name, extension);
        }
    }
}
