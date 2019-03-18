using System;
using System.Threading.Tasks;

namespace SchrackPOC.Services
{
    public interface IDatabaseSeedService
    {
        #region Public Methods

        /// <summary>
        /// Copies the bundled database to a directory for use
        /// </summary>
        /// <param name="directoryPath">The path to copy the database to</param>
        /// <returns>An <c>await</c>able <see cref="Task"/> representing the copy operation</returns>
        Task CopyDatabaseAsync(string directoryPath);

        #endregion
    }
}
