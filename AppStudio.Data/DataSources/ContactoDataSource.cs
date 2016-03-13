using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppStudio.Data
{
    public class ContactoDataSource : DataSourceBase<MenuSchema>
    {
        private const string _file = "/Assets/Data/ContactoDataSource.json";

        protected override string CacheKey
        {
            get { return "ContactoDataSource"; }
        }

        public override bool HasStaticData
        {
            get { return true; }
        }

        public async override Task<IEnumerable<MenuSchema>> LoadDataAsync()
        {
            try
            {
                var serviceDataProvider = new StaticDataProvider(_file);
                return await serviceDataProvider.Load<MenuSchema>();
            }
            catch (Exception ex)
            {
                AppLogs.WriteError("ContactoDataSource.LoadData", ex.ToString());
                return new MenuSchema[0];
            }
        }

    }
}
