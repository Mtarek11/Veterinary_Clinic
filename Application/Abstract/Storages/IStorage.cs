using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DTOs;

namespace Application.Abstract.Storages
{
    public interface IStorage
    {
        Task<List<UploadDto>> UploadAsync(IFormFileCollection files, string path);
        void Delete(string path);
    }
}
