using IdeaManager.Data;
using IdeaManager.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using IdeaManager.UI.Navigation;
using IdeaManager.UI.ViewModels;

namespace IdeaManager.UI;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    public static IServiceProvider? ServiceProvider { get; private set; }

    protected override void OnStartup(StartupEventArgs e)
    {
        var services = new ServiceCollection();

        services.AddDataServices("Data Source=D:\\Labo-Entreprise\\IdeaManager.Data\\ideas.db");

        services.AddDomainServices();
        services.AddUIServices();

        services.AddSingleton<INavigationService, NavigationService>();
        services.AddSingleton<MainViewModel>();
        services.AddSingleton<IdeaFormViewModel>();
        services.AddSingleton<IdeaListViewModel>();
        services.AddSingleton<MainWindow>();

        ServiceProvider = services.BuildServiceProvider();

        var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
        mainWindow.Show();
    }

}