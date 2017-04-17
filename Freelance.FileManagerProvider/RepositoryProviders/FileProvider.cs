using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Freelance.FileManagerProvider.Interfaces;
using Freelance.FileManagerProvider.Repositories;

namespace Freelance.FileManagerProvider
{
    public abstract class FileProvider<TRepositoryPath>
        where TRepositoryPath:IRepositoryPath,new()
    {

        protected string Path { get; set; }
        protected string AppPath { get; set; }
        protected IRepositoryPath RepositPath { get; set; }
        public FileProvider()
        {
            RepositPath = new TRepositoryPath();
            Path = RepositPath.RepositoryPath();
        }
        public virtual Guid Create(string content, string userId)
        {
            string userPath;
            if (RepositPath is AdminRepositoryPath)
                userPath = PathGeneration(AppPath,Path);
            else
                userPath = PathGeneration(AppPath,Path,userId);

            var fileId = Guid.NewGuid();
            Сheck(userPath);

            using (FileStream stream = new FileStream(PathGeneration(userPath,fileId.ToString()),FileMode.Create))
            {
                byte[] array = Encoding.Default.GetBytes(content);
                stream.Write(array, 0, array.Length);
                return fileId;
            }
        }
        public virtual string GetFile(Guid fileId, string userId)
        {

            using (FileStream stream = File.OpenRead(PathGeneration(userId,fileId.ToString())))
            {
                byte[] array = new byte[stream.Length];
                stream.Read(array, 0, array.Length);
                   
                return Encoding.Default.GetString(array);
            }

        }
        public virtual void Delete(Guid FileId, string userId)
        {

        }
        public void SetPath(string path)
        {
            AppPath = path;
            Сheck(AppPath);
        }
        protected string PathGeneration(params string[] names)
        {
            var path = new StringBuilder(names[0]);
            for (int i = 1;i < names.Length ;i++)
            {
                
                path.Append(String.Format(@"\{0}",names[i]));
            }

            return path.ToString();
        }

        protected void Сheck(string path)
        { 
            var dirInfo = new DirectoryInfo(Path);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }
        }
    }
}
