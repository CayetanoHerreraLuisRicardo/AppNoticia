using System;

using Windows.ApplicationModel;

namespace AppStudio.ViewModels
{
    public class AboutThisAppViewModel
    {
        public string Publisher
        {
            get
            {
                return "RichyCH";
            }
        }

        public string AppVersion
        {
            get
            {
                return string.Format("{0}.{1}.{2}.{3}", Package.Current.Id.Version.Major, Package.Current.Id.Version.Minor, Package.Current.Id.Version.Build, Package.Current.Id.Version.Revision);
            }
        }

        public string AboutText
        {
            get
            {
                return "La Aplicacion AppNoticias contiene una recolipación de los mejores diarios y blog" +
    "s conocidos a quí en México, con una variedad de noticias, novedades el cual tie" +
    "ne como fin poderte informar de las ultimas noticias.";
            }
        }
    }
}

