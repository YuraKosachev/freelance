using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Freelance.FileManagerProvider.Interfaces;

namespace Freelance.FileManagerProvider
{
    public class FilePathSettings
    {
        public static string Path { get; private set; }
        public static void SetPath(string appPath)
        {
            Path = appPath;
        }
    }
}
