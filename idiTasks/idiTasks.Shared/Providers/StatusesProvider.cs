using System.Collections.ObjectModel;

namespace idiTasks.Shared.Providers
{
    public class StatusesProvider
    {
        public StatusesProvider()
        {
            Statuses = new ObservableCollection<StatusEnum>
            {
                StatusEnum.New,
                StatusEnum.Finished,
                StatusEnum.Abandoned
            };
        }

        public ObservableCollection<StatusEnum> Statuses { get; set; }

        public enum StatusEnum
        {
            New,
            Finished,
            Abandoned
        }
    }
}
