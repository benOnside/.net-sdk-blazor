﻿using System.Threading.Tasks;

namespace ConfigCat.Client.ConfigService
{
    internal sealed class ManualPollConfigService : ConfigServiceBase, IConfigService
    {
        internal ManualPollConfigService(IConfigFetcher configFetcher, IConfigCache configCache, ILogger logger)
            : base(configFetcher, configCache, logger) { }

        public Task<ProjectConfig> GetConfigAsync()
        {
            var config = this.configCache.Get();

            return Task.FromResult(config);
        }

        public async Task RefreshConfigAsync()
        {
            var config = this.configCache.Get();

            config = await this.configFetcher.Fetch(config).ConfigureAwait(false);

            this.configCache.Set(config);
        }
    }
}