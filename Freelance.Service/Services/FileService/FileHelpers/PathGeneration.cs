using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Freelance.Service.FileManagerConfg;

namespace Freelance.Service.Interfaces.FileServices.FileHelpers
{
    //public static class PathGeneration
    //{
    //    public static string FilePathGeneration(this AppFolder appPath, params string[] names)
    //    {
    //        var path = new StringBuilder(appPath.AppPath);
    //        for (int i = 1; i < names.Length; i++)
    //        {

    //            path.Append(String.Format(@"\{0}", names[i]));
    //        }

    //    }
    //}
}


protected string PathGeneration(params string[] names)
{
    var path = new StringBuilder(names[0]);
    for (int i = 1; i < names.Length; i++)
    {

        path.Append(String.Format(@"\{0}", names[i]));
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