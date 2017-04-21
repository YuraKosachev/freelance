using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freelance.FileManagerProvider
{
    public class CreateFile : ICreatable
    {
        public void Create(byte[] content, string path, string fileExtension)
        {
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                stream.Write(content, 0, content.Length);
            }
        }
    }
}
