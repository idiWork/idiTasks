# Code fragments

Fragmento 1:

```cs
public class StatusesProvider
{
    public enum StatusEnum
    {
        New,
        Finished,
        Abandoned
    }
}
```

Fragmento 2:

```cs
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
```

Fragmento 3:

```cs
public class ProjectItem
{
    public string Title { get; set; }
    public string Description { get; set; }
    public StatusEnum Status { get; set; }

    public ObservableCollection<StatusEnum> StatusList { get; set; }
}
```

Fragmento 4:

```cs
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
}
```

Fragment 5:

```cs
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
}
```

Fragment 6:

```xml
<Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}" >
        <Grid.RowDefinitions>
            <RowDefinition Height="Auto" />
            <RowDefinition Height="*" />
        </Grid.RowDefinitions>
</Grid>
```

Fragment 7:

```xml
<Button Content="Add new project"
        Margin="10"
        FontSize="15"
        Background="CornflowerBlue"
        Foreground="White"
        Grid.Row="0"/>
```

Fragment 8:

```xml
<Page
    ... more XAML imports ...
    xmlns:Models="using:idiTasks.Shared.Models">
```

Fragment 9:

```xml
<Grid>
    <!-- More code: RowDefintions and Button -->
    <ListView ItemsSource="{x:Bind viewModel.Projects}"
              SelectionMode="Single"
              Grid.Row="1">
        <ListView.ItemTemplate>
            <DataTemplate x:DataType="Models:ProjectItem">
                <StackPanel Grid.Row="1" Orientation="Horizontal" Padding="5">
                    <TextBox Header="Title"
                             PlaceholderText="Insert title here"
                             Text="{x:Bind Title, Mode=TwoWay}"
                             Width="200"
                             Height="70"
                             AcceptsReturn="False"
                             TextWrapping="NoWrap"
                             Margin="5"/>
                    <ComboBox Header="Type"
                             ItemsSource="{x:Bind StatusList}"
                             SelectedItem="{x:Bind Status, Mode=TwoWay}"
                             Width="150"
                             Margin="5, 20"/>
                    <TextBox Header="Description"
                             PlaceholderText="Enter text here"
                             Text="{x:Bind Description, Mode=TwoWay}"
                             AcceptsReturn="True"
                             Height="100"
                             Width="200"
                             Margin="5"/>
                </StackPanel>
            </DataTemplate>
        </ListView.ItemTemplate>
    </ListView>
<Grid>
```

Fragment 10:

```xml
<Button Content="Add new project"
        Click="AddNewItem_Click"
        Margin="10"
        FontSize="15"
        Background="CornflowerBlue"
        Foreground="White"
        Grid.Row="0"/>
```

Fragment 11:

```cs
public class MainViewModel
{
    // Previous code

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
```

Fragment 12:

```cs
public sealed partial class MainPage : Page
{
    // Previous code

    private void AddNewItem_Click(object sender, RoutedEventArgs e)
    {
        viewModel.AddNewProject();
    }
}
```

Fragment 13:

```xml
<UserControl
    ...
    d:DesignHeight="100"
    d:DesignWidth="400">

    <Grid Background="White">
        <Grid.RowDefinitions>
            <RowDefinition/>
        </Grid.RowDefinitions>
        <StackPanel Grid.Row="0"
                    Orientation="Horizontal"
                    Padding="5"
                    MaxHeight="100">
            <TextBox Header="Title"
                     PlaceholderText="Insert title here"
                     Text="{Binding Title, Mode=TwoWay}"
                     Width="200"
                     Height="70"
                     AcceptsReturn="False"
                     TextWrapping="NoWrap"
                     Margin="5"/>
            <ComboBox Header="Type"
                      ItemsSource="{Binding StatusList}"
                      SelectedItem="{Binding Status, Mode=TwoWay}"
                      Width="150"
                      Margin="5"/>
            <TextBox Header="Description"
                     PlaceholderText="Enter text here"
                     Text="{Binding Description, Mode=TwoWay}"
                     AcceptsReturn="True"
                     Width="200"
                     Margin="5"/>
        </StackPanel>
    </Grid>
</UserControl>
```

Fragment 14:

```xml
<ListView.ItemTemplate>
    <DataTemplate x:DataType="Models:ProjectItem">
        <Controls:ProjectItemControl/>
    </DataTemplate>
</ListView.ItemTemplate>
```

Fragment 15:

```xml
<Page
    ... more XAML imports ...
    xmlns:Controls="using:idiTasks.Shared.Controls">
```
