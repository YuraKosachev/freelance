using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Freelance.Service.Interfaces;
using Microsoft.Practices.Unity;
using Freelance.FileManagerProvider.Interfaces;

namespace Freelance.Service.Services
{
    public class TextFileService : FileService, ITextFilesService
    {
        [InjectionConstructor]
        public TextFileService(ITextFilesProvider fileProvider) : base(fileProvider) { }
    }
}
