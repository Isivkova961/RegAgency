using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using RecrutmentAgency.Data;
using RecrutmentAgency.Data.Repositories;

namespace RecrutmentAgency.Files
{
    public class DbFileProvider : IFileProvider
    {
        private PhotoFileContentRepository photoFileContentRepository;

        public DbFileProvider(PhotoFileContentRepository photoFileContentRepository)
        {
            this.photoFileContentRepository = photoFileContentRepository;
        }

        public string Name => "Database";

        public Stream Load(PhotoFile file)
        {
            var content = photoFileContentRepository.GetByBinaryFile(file);
            if (content == null || content.Content == null)
            {
                return null;
            }
            var path = Path.GetTempFileName();
            var fileName = Path.GetFileNameWithoutExtension(path);
            var extension = Path.GetExtension(file.FileName);
            var fullPath = Path.Combine(Path.GetDirectoryName(path), $"{fileName}{extension}");
            using (var stream = new FileStream(fullPath, FileMode.CreateNew))
            {
                stream.Write(content.Content, 0, content.Content.Length);
            }
            return new FileStream(fullPath, FileMode.Open);
        }
        public void Save(PhotoFile file, Stream content)
        {
            var contentF = new PhotoFileContent
            {
                PhotoFile = file,
                Content = content.ToByteArray()
            };
            photoFileContentRepository.Save(contentF);
        }
    }
}