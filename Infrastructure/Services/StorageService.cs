using Application.Abstract.Storages;
using Application.Services;
using Domain.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class StorageService(IStorage storage) : IStorageService
    {
        private readonly IStorage _storage = storage;

        public string StorageName => _storage.GetType().Name;

        public void Delete(string path) => _storage.Delete(path);

        public Task<List<UploadDto>> UploadAsync(IFormFileCollection files, string path) => _storage.UploadAsync(files, path);
    }
}
