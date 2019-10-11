using idiTasks.Shared.Models;
using idiTasks.Shared.Providers;
using System.Collections.ObjectModel;
using static idiTasks.Shared.Providers.StatusesProvider;

namespace idiTasks.Shared.ViewModels
{
    public class MainViewModel
    {
        private readonly StatusesProvider _provider;

        public MainViewModel(StatusesProvider provider)
        {
            _provider = provider;
            PossibleStatus = _provider.Statuses;

            Projects = new ObservableCollection<ProjectItem>();
        }

        public ObservableCollection<ProjectItem> Projects { get; set; }

        public ObservableCollection<StatusEnum> PossibleStatus { get; set; }

        public void AddNewProject()
        {
            Projects.Add(
                new ProjectItem
                {
                    Title = "No title",
                    Description = "Empty description",
                    Status = StatusEnum.New,
                    StatusList = PossibleStatus
                });
        }
    }
}
