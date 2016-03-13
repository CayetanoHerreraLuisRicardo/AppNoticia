using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppStudio.Data
{
    public class NoPuedoCreerDataSource : DataSourceBase<RssSchema>
    {
        private const string _url =@"http://feeds2.feedburner.com/NoPuedoCreerQueLoHayanInventado";

        protected override string CacheKey
        {
            get { return "NoPuedoCreerDataSource"; }
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
                AppLogs.WriteError("NoPuedoCreerDataSourceDataSource.LoadData", ex.ToString());
                return new RssSchema[0];
            }
        }
    }
}
