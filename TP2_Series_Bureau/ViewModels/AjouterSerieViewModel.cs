using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TP2_Series_Bureau.Models;

namespace TP2_Series_Bureau.ViewModels
{
    public class AjouterSerieViewModel : ObservableObject
    {
        private Serie serieAAjouter = new Serie(1, "test", "résumé", 1, 2, 3, "network");
        public Serie SerieAAjouter
        {
            get => serieAAjouter;
            set
            {
                serieAAjouter = value;
                OnPropertyChanged();
            }
        }

        public AjouterSerieViewModel()
        {
        }
    }
}
