using Application.Repositories.Files;
using Domain.Comman;
using Persistence.Contexts;
using Persistence.Repositories.BaseRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.Files
{
    public class FileQueryRepository : QueryRepository<BaseFile>, IFileQueryRepository
    {
        public FileQueryRepository(Context context) : base(context) { }
    }
}
