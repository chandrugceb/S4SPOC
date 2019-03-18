using System;
using System.IO;
using System.Threading.Tasks;
using Foundation;
using SchrackPOC.Services;

namespace SchrackPOC.iOS.Services
{
    /// <summary>
    /// An implementation of <see cref="IDatabaseSeedService"/> that reads the prebuilt
    /// database from the main application bundle
    /// </summary>
    public class DatabaseSeedService : IDatabaseSeedService
    {
        #region IDatabaseSeedService

        public async Task CopyDatabaseAsync(string directoryPath)
        {
            //var finalPath = Path.Combine(directoryPath, "travel-sample.cblite2");
            var finalPath = Path.Combine(directoryPath, "db.cblite2");
            Directory.CreateDirectory(finalPath);
            //var sourcePath = Path.Combine(NSBundle.MainBundle.ResourcePath, "travel-sample.cblite2");
            var sourcePath = Path.Combine(NSBundle.MainBundle.ResourcePath, "db.cblite2");
            var dirInfo = new DirectoryInfo(sourcePath);
            foreach (var file in dirInfo.EnumerateFiles())
            {
                using (var inStream = File.OpenRead(file.FullName))
                using (var outStream = File.OpenWrite(Path.Combine(finalPath, file.Name)))
                {
                    await inStream.CopyToAsync(outStream);
                }
            }
        }

        #endregion
    }
}
