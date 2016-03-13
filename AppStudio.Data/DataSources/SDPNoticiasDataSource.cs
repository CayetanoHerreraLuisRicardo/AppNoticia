using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppStudio.Data
{
    public class SDPNoticiasDataSource : DataSourceBase<RssSchema>
    {
        private const string _url =@"http://feeds.sdpnoticias.com/portal/all?_ga=1.112463297.49693296.1417486918";

        protected override string CacheKey
        {
            get { return "SDPNoticiasDataSource"; }
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
                AppLogs.WriteError("SDPNoticiasDataSourceDataSource.LoadData", ex.ToString());
                return new RssSchema[0];
            }
        }
    }
}
