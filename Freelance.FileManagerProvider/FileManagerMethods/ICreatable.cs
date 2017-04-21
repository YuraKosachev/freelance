using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freelance.FileManagerProvider
{
    public interface ICreatable
    {
        void Create(byte[] content, string path, string fileExtension);
    }
}
