using System;
using System.Collections;
using Newtonsoft.Json;

namespace AppStudio.Data
{
    /// <summary>
    /// Implementation of the AcercaDeSchema class.
    /// </summary>
    public class AcercaDeSchema : BindableSchemaBase, IEquatable<AcercaDeSchema>, ISyncItem<AcercaDeSchema>
    {
        private string _aplicación;
        private string _nombre;
        private string _autor;
        private string _ocupación;
        private string _ciudad;
        [JsonProperty("_id")]
        public string Id { get; set; }

 
        public string Aplicación
        {
            get { return _aplicación; }
            set { SetProperty(ref _aplicación, value); }
        }
 
        public string Nombre
        {
            get { return _nombre; }
            set { SetProperty(ref _nombre, value); }
        }
 
        public string Autor
        {
            get { return _autor; }
            set { SetProperty(ref _autor, value); }
        }
 
        public string Ocupación
        {
            get { return _ocupación; }
            set { SetProperty(ref _ocupación, value); }
        }
 
        public string Ciudad
        {
            get { return _ciudad; }
            set { SetProperty(ref _ciudad, value); }
        }

        public override string DefaultTitle
        {
            get { return Nombre; }
        }

        public override string DefaultSummary
        {
            get { return Autor; }
        }

        public override string DefaultImageUrl
        {
            get { return Aplicación; }
        }

        public override string DefaultContent
        {
            get { return Autor; }
        }

        override public string GetValue(string fieldName)
        {
            if (!String.IsNullOrEmpty(fieldName))
            {
                switch (fieldName.ToLowerInvariant())
                {
                    case "aplicación":
                        return String.Format("{0}", Aplicación); 
                    case "nombre":
                        return String.Format("{0}", Nombre); 
                    case "autor":
                        return String.Format("{0}", Autor); 
                    case "ocupación":
                        return String.Format("{0}", Ocupación); 
                    case "ciudad":
                        return String.Format("{0}", Ciudad); 
                    case "defaulttitle":
                        return DefaultTitle;
                    case "defaultsummary":
                        return DefaultSummary;
                    case "defaultimageurl":
                        return DefaultImageUrl;
                    default:
                        break;
                }
            }
            return String.Empty;
        }

        public bool Equals(AcercaDeSchema other)
        {
            if (ReferenceEquals(this, other)) return true;
            if (ReferenceEquals(null, other)) return false;
            return this.Id == other.Id;
        }

        public bool NeedSync(AcercaDeSchema other)
        {

            return this.Id == other.Id && (this.Aplicación != other.Aplicación || this.Nombre != other.Nombre || this.Autor != other.Autor || this.Ocupación != other.Ocupación || this.Ciudad != other.Ciudad);
        }

        public void Sync(AcercaDeSchema other)
        {
            this.Aplicación = other.Aplicación;
            this.Nombre = other.Nombre;
            this.Autor = other.Autor;
            this.Ocupación = other.Ocupación;
            this.Ciudad = other.Ciudad;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as AcercaDeSchema);
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
    }
}
