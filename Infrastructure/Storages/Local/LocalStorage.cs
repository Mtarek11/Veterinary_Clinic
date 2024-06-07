using Application.Abstract.Storages.Local;
using Domain.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.Identity.Client.Extensions.Msal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Storages.Local
{
    public class LocalStorage : Storage, ILocalStorage
    {
        public void Delete(string path)
        {
            if (File.Exists(path)) File.Delete(path);
        }

        public async Task<List<UploadDto>> UploadAsync(IFormFileCollection files, string path)
        {
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);

            List<UploadDto> datas = new();
            foreach (var file in files)
            {
                var extension = Path.GetExtension(file.FileName);
                var guid = Guid.NewGuid().ToString();
                var root = guid + extension;
                await CopyFileAsync(file, root, path);
                datas.Add(new() { FileName = file.FileName, Path = root + path });
            }
            return datas;
        }

        private async Task CopyFileAsync(IFormFile file, string root, string path)
        {
            using (FileStream fileStream = File.Create(path + root))
            {
                await file.CopyToAsync(fileStream);
                await fileStream.FlushAsync();
            }
        }
    }
}
