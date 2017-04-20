using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Freelance.Service.Interfaces;
using Freelance.FileManagerProvider.Interfaces;

namespace Freelance.Service.Services    
{
    public abstract class FileService:IFileService
    {
        protected IFileProvider FileProvider { get; set; }
        public FileService(IFileProvider fileProvider)
        {
            FileProvider = fileProvider;
        }
        public virtual Guid Create(string content, string userId)
        {
            return FileProvider.Create(content, userId);
        }

        public virtual string GetFile(Guid fileId, string userId)
        {
            return FileProvider.GetFile(fileId,userId);
        }

        public virtual void Delete(Guid fileId, string userId)
        {
            FileProvider.Delete(fileId, userId);
        }

        
        public string Create(string content, string folderName, string fileExtension)
        {
            return FileProvider.Create(content, folderName, fileExtension);
        }
    }
}
