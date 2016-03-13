using System;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Net.NetworkInformation;

using Windows.UI.Xaml;

using AppStudio.Services;
using AppStudio.Data;

namespace AppStudio.ViewModels
{
    public class MainViewModel : BindableBase
    {
       private DiariosDeMexicoYElMundoViewModel _diariosDeMexicoYElMundoModel;
       private ActualidadYNovedadesViewModel _actualidadYNovedadesModel;
       private SoftwareHardwareEInternetViewModel _softwareHardwareEInternetModel;
       private ContactoViewModel _contactoModel;
       private AcercaDeViewModel _acercaDeModel;
        private PrivacyViewModel _privacyModel;

        private ViewModelBase _selectedItem = null;

        public MainViewModel()
        {
            _selectedItem = DiariosDeMexicoYElMundoModel;
            _privacyModel = new PrivacyViewModel();

        }
 
        public DiariosDeMexicoYElMundoViewModel DiariosDeMexicoYElMundoModel
        {
            get { return _diariosDeMexicoYElMundoModel ?? (_diariosDeMexicoYElMundoModel = new DiariosDeMexicoYElMundoViewModel()); }
        }
 
        public ActualidadYNovedadesViewModel ActualidadYNovedadesModel
        {
            get { return _actualidadYNovedadesModel ?? (_actualidadYNovedadesModel = new ActualidadYNovedadesViewModel()); }
        }
 
        public SoftwareHardwareEInternetViewModel SoftwareHardwareEInternetModel
        {
            get { return _softwareHardwareEInternetModel ?? (_softwareHardwareEInternetModel = new SoftwareHardwareEInternetViewModel()); }
        }
 
        public ContactoViewModel ContactoModel
        {
            get { return _contactoModel ?? (_contactoModel = new ContactoViewModel()); }
        }
 
        public AcercaDeViewModel AcercaDeModel
        {
            get { return _acercaDeModel ?? (_acercaDeModel = new AcercaDeViewModel()); }
        }

        public void SetViewType(ViewTypes viewType)
        {
            DiariosDeMexicoYElMundoModel.ViewType = viewType;
            ActualidadYNovedadesModel.ViewType = viewType;
            SoftwareHardwareEInternetModel.ViewType = viewType;
            ContactoModel.ViewType = viewType;
            AcercaDeModel.ViewType = viewType;
        }

        public ViewModelBase SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                SetProperty(ref _selectedItem, value);
                UpdateAppBar();
            }
        }

        public Visibility AppBarVisibility
        {
            get
            {
                return SelectedItem == null ? AboutVisibility : SelectedItem.AppBarVisibility;
            }
        }

        public Visibility AboutVisibility
        {

      get { return Visibility.Collapsed; }
        }

        public void UpdateAppBar()
        {
            OnPropertyChanged("AppBarVisibility");
            OnPropertyChanged("AboutVisibility");
        }

        /// <summary>
        /// Load ViewModel items asynchronous
        /// </summary>
        public async Task LoadDataAsync(bool forceRefresh = false)
        {
            var loadTasks = new Task[]
            { 
                DiariosDeMexicoYElMundoModel.LoadItemsAsync(forceRefresh),
                ActualidadYNovedadesModel.LoadItemsAsync(forceRefresh),
                SoftwareHardwareEInternetModel.LoadItemsAsync(forceRefresh),
                ContactoModel.LoadItemsAsync(forceRefresh),
                AcercaDeModel.LoadItemsAsync(forceRefresh),
            };
            await Task.WhenAll(loadTasks);
        }

        //
        //  ViewModel command implementation
        //
        public ICommand RefreshCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    await LoadDataAsync(true);
                });
            }
        }

        public ICommand AboutCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    NavigationServices.NavigateToPage("AboutThisAppPage");
                });
            }
        }

        public ICommand PrivacyCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    NavigationServices.NavigateTo(_privacyModel.Url);
                });
            }
        }
    }
}
