using Microsoft.UI.Xaml.Controls;
using TP2_Series_Bureau.ViewModels;

namespace TP2_Series_Bureau.Views
{
    public sealed partial class AjouterSerieView : Page
    {
        public AjouterSerieView()
        {
            InitializeComponent();
            DataContext = App.Current.Services.GetService(typeof(AjouterSerieViewModel));
        }
    }
}
