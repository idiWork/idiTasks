using idiTasks.Shared.Providers;
using idiTasks.Shared.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;


namespace idiTasks
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        MainViewModel viewModel;

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            viewModel = new MainViewModel(new StatusesProvider());
        }

        private void AddNewItem_Click(object sender, RoutedEventArgs e)
        {
            viewModel.AddNewProject();
        }
    }
}
