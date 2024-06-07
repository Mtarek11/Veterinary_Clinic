using Application.Abstract.Storages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IStorageService : IStorage
    {
        string StorageName { get; }
    }
}
