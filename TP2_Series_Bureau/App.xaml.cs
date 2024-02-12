using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using TP2_Series_Bureau.ViewModels;
using TP2_Series_Bureau.Views;
using Microsoft.Extensions.DependencyInjection;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace TP2_Series_Bureau
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    public partial class App : Application
    {
        public ServiceProvider Services { get; set; }

        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            InitializeComponent();

            var services = new ServiceCollection();

            // ViewModels :
            services.AddTransient<AjouterSerieViewModel>();
            services.AddTransient<ModifierSupprimerSerieViewModel>();

            Services = services.BuildServiceProvider();
        }

        public new static App Current => (App)Application.Current;

        public static FrameworkElement? MainRoot { get; private set; }

        /// <summary>
        /// Invoked when the application is launched.
        /// </summary>
        /// <param name="args">Details about the launch request and process.</param>
        protected override void OnLaunched(LaunchActivatedEventArgs args)
        {
            m_window = new MainWindow();
            // Création d'un Frame qui agira comme le contexte de naviagtion
            RootFrame = new Frame();
            // Placement du Frame dans la fenêtre principale
            m_window.Content = RootFrame;
            // On active la fenêtre actuelle
            m_window.Activate();
            // Navigation à la première page
            RootFrame.Navigate(typeof(ModifierSupprimerSerieView));

            MainRoot = (FrameworkElement)m_window.Content;
        }

        public Frame? RootFrame { get; private set; }

        private Window? m_window;
    }
}
