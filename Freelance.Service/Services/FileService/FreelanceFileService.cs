using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using Freelance.Service.Interfaces;
using Freelance.FileManagerProvider.Interfaces;
using Freelance.Service.FileManagerConfg;

namespace Freelance.Service.Services
{
    public abstract class FreelanceFileService : IFileService
    {
        protected string Path { get; set; }
        protected IFileProvider FileProvider { get; set; }
        protected AppFolder Folders { get; set; }
        public FreelanceFileService(IFileProvider provider)
        {
            FileProvider = provider;
            Folders = FilePathConfiguration.Folders;
        }
        public string Create(byte[] content, string userId, string fileExtension)
        {
            var path = FolderPath(userId);
            Сheck(path);
            return FileProvider.Create(content,fileExtension,file => PathGeneration(path,file));
        }

        public string Create(string base64Content, string userId, Func<string, byte[]> convert)
        {
            byte[] content = convert(base64Content);
            return Create(content, userId, "png");
        }

        public void Delete(Guid fileId, string userId)
        {
            throw new NotImplementedException();
        }

        public string GetFile(Guid fileId, string userId)
        {
            throw new NotImplementedException();
        }
        protected virtual string FolderPath(string folderName)
        {
            return PathGeneration(Path, folderName);
        }
        protected string PathGeneration(string path, string name)
        {
            return String.Format(@"{0}\{1}",path,name);
        }
        protected void Сheck(string path)
        {
            var dirInfo = new DirectoryInfo(path);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }
        }
    }
}
