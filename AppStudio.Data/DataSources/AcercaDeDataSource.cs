using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppStudio.Data
{
    public class AcercaDeDataSource : DataSourceBase<AcercaDeSchema>
    {
        private const string _file = "/Assets/Data/AcercaDeDataSource.json";

        protected override string CacheKey
        {
            get { return "AcercaDeDataSource"; }
        }

        public override bool HasStaticData
        {
            get { return false; }
        }

        public async override Task<IEnumerable<AcercaDeSchema>> LoadDataAsync()
        {
            try
            {
                var serviceDataProvider = new StaticDataProvider(_file);
                return await serviceDataProvider.Load<AcercaDeSchema>();
            }
            catch (Exception ex)
            {
                AppLogs.WriteError("AcercaDeDataSource.LoadData", ex.ToString());
                return new AcercaDeSchema[0];
            }
        }
    }
}
