using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Freelance.FileManagerProvider.Interfaces;
using Freelance.FileManagerProvider.Repositories;

namespace Freelance.FileManagerProvider.RepositoryProviders
{
    public class PhotosRepositoryProvider : FileProvider<PhotoRepositoryPath>, IPhotoProvider
    {
        public PhotosRepositoryProvider() : base() { }
    }
}
