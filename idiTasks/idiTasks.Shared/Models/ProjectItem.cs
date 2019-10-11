using System.Collections.ObjectModel;
using static idiTasks.Shared.Providers.StatusesProvider;

namespace idiTasks.Shared.Models
{
    public class ProjectItem
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public StatusEnum Status { get; set; }
        
        public ObservableCollection<StatusEnum> StatusList { get; set; }
    }
}
