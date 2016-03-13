using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppStudio.Data
{
    public class LaJornadaDataSource : DataSourceBase<RssSchema>
    {
        private const string _url =@"http://lajornada.dynamic.feedsportal.com/pf/626145/www.jornada.unam.mx/rss/edicion.xml";

        protected override string CacheKey
        {
            get { return "LaJornadaDataSource"; }
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
                AppLogs.WriteError("LaJornadaDataSourceDataSource.LoadData", ex.ToString());
                return new RssSchema[0];
            }
        }
    }
}
