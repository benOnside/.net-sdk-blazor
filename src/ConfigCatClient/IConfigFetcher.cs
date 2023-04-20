using System.Threading;
using System.Threading.Tasks;

namespace ConfigCat.Client;

/// <summary>
/// Defines configuration fetch
/// </summary>
internal interface IConfigFetcher
{
    /// <summary>
    /// Fetches the configuration asynchronously.
    /// </summary>
    /// <param name="lastConfig">Last fetched configuration if it is present</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>The task that does the fetch.</returns>
    Task<FetchResult> FetchAsync(ProjectConfig lastConfig, CancellationToken cancellationToken = default);

    /// <summary>
    /// Fetches the configuration synchronously.
    /// </summary>
    /// <param name="lastConfig">Last fetched configuration if it is present</param>
    /// <returns>The fetched config.</returns>
    FetchResult Fetch(ProjectConfig lastConfig);
}
