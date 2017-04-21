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
    public abstract class FileProvider<TRepositoryPath, TCreateFile>
        where TRepositoryPath:IRepositoryPath,new()
        where TCreateFile : ICreatable, new()
    {

        protected string Path { get; set; }
        protected string AppPath { get; set; }
        protected ICreatable CreateFile { get; set; }
        protected IRepositoryPath RepositPath { get; set; }
        public FileProvider()
        {
            RepositPath = new TRepositoryPath();
            CreateFile = new TCreateFile();
            Path = RepositPath.RepositoryPath();
            AppPath = FilePathSettings.Path; 
        }
        public virtual string Create(string base64Content, string folderName,Func<string,byte[]> convert)
        {
            byte[] array = convert(Base64ImageContent(base64Content));//Convert.FromBase64String(Base64ImageContent(base64Content));
            return Create(array, folderName, "png");
        }
      
        public virtual string Create(byte[] content, string folderName,string fileExtension)
        {

            var userPath = FolderPath(folderName);
            var fileId = Guid.NewGuid();
            Сheck(userPath);
            var fileName = FileName(fileId, fileExtension);
            CreateFile.Create(content,PathGeneration(userPath, fileName), fileExtension);
            return fileName;
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
        protected string FileName<TType>(TType source,string format) 
        {
            return String.Format("{0}.{1}",source,format);
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
        protected string FolderPath(string folderName)
        {

            if (RepositPath is AdminRepositoryPath)
            {
                return PathGeneration(AppPath, Path);
            }
            return PathGeneration(AppPath, Path, folderName);
            

        }
        protected string Base64ImageContent(string base64Content)//,out string extension)
        {
            return base64Content.Replace("data:image/png;base64,", "");
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
