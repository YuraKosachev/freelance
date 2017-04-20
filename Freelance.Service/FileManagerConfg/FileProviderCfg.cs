
using Freelance.FileManagerProvider;

namespace Freelance.Service.FileManagerConfg
{
    public class FileProviderCfg
    {
        public static void AppPath(string path)
        {
            FilePathSettings.SetPath(path);
        }
    }
}
