using AppStudio.Services;
using AppStudio.ViewModels;

using Windows.ApplicationModel.DataTransfer;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace AppStudio.Views
{
    public sealed partial class AcercaDeDetail : Page
    {
        private NavigationHelper _navigationHelper;

        private DataTransferManager _dataTransferManager;

        public AcercaDeDetail()
        {
            this.InitializeComponent();
            _navigationHelper = new NavigationHelper(this);

            AcercaDeModel = new AcercaDeViewModel();
        }

        public AcercaDeViewModel AcercaDeModel { get; private set; }

        public NavigationHelper NavigationHelper
        {
            get { return _navigationHelper; }
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            _dataTransferManager = DataTransferManager.GetForCurrentView();
            _dataTransferManager.DataRequested += OnDataRequested;

            _navigationHelper.OnNavigatedTo(e);

            if (AcercaDeModel != null)
            {
                await AcercaDeModel.LoadItemsAsync();
                AcercaDeModel.SelectItem(e.Parameter);

                AcercaDeModel.ViewType = ViewTypes.Detail;
            }
            DataContext = this;
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            _navigationHelper.OnNavigatedFrom(e);
            _dataTransferManager.DataRequested -= OnDataRequested;
        }

        private void OnDataRequested(DataTransferManager sender, DataRequestedEventArgs args)
        {
            if (AcercaDeModel != null)
            {
                AcercaDeModel.GetShareContent(args.Request);
            }
        }
    }
}
