using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppStudio.Data
{
    public class GizmodoDataSource : DataSourceBase<RssSchema>
    {
        private const string _url =@"http://feeds.gawker.com/esgizmodo/full#_ga=1.230499038.390665946.1426356448";

        protected override string CacheKey
        {
            get { return "GizmodoDataSource"; }
        }

        public override bool HasStaticData
        {
            get { return false; }
        }

        public async override Task<IEnumerable<RssSchema>> LoadDataAsync()
        {
            try
            {
                var rssDataProvider = new RssDataProvider(_url);
                return await rssDataProvider.Load();
            }
            catch (Exception ex)
            {
                AppLogs.WriteError("GizmodoDataSourceDataSource.LoadData", ex.ToString());
                return new RssSchema[0];
            }
        }
    }
}
