using Application.Boundaries.Services;
using Domain.Components.Blocks;
using Infrastructure.IO.Helpers;
using Newtonsoft.Json;
using System.Text;

namespace Infrastructure.IO.Services
{
    public class WebsiteBlocksFileService : IWebsiteBlocksFileService
    {
        public static string GetFileName(string key) => $"{key}.json";
        public static string GetFilePath(string key) => Path.Combine(Directory.GetCurrentDirectory(), "WebsiteBlocksFiles", GetFileName(key));
        public static string GetFileDirectory() => Path.Combine(Directory.GetCurrentDirectory(), "WebsiteBlocksFiles");

        public async Task CreateAsync(
            string key,
            IEnumerable<IBlock> blocks,
            CancellationToken cancellationToken)
        {
            var fileName = GetFileName(key);
            var directory = GetFileDirectory();
            var filePath = GetFilePath(key);

            bool directoryExists = Directory.Exists(directory);
            if (!directoryExists)
                Directory.CreateDirectory(directory);

            if (File.Exists(filePath))
                throw new Exception($"File '{fileName}' already exists");

            var textBlocks = JsonConvert.SerializeObject(blocks, new JsonSerializerSettings()
            {
                ContractResolver = new StaticPropertyContractResolver()
            });

            using (var outputFile = new StreamWriter(filePath))
            {
                await outputFile.WriteAsync(new StringBuilder(textBlocks), cancellationToken);
            }
        }

        public async Task<string> GetAsync(string key, CancellationToken cancellationToken)
        {
            var fileName = GetFileName(key);
            var filePath = GetFilePath(key);

            if (!File.Exists(filePath))
                throw new Exception($"File '{fileName}' does not exist");

            return await File.ReadAllTextAsync(filePath, cancellationToken);
        }

        public async Task UpdateAsync(string key, IEnumerable<IBlock> blocks, CancellationToken cancellationToken)
        {
            Delete(key);
            await CreateAsync(key, blocks, cancellationToken);
        }

        public void Delete(string key)
        {
            var fileName = GetFileName(key);
            var filePath = GetFilePath(key);

            if (!File.Exists(filePath))
                throw new Exception($"File '{fileName}' does not exist");

            File.Delete(filePath);
        }
    }
}
