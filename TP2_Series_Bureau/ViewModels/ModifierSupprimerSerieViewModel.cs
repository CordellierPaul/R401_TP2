using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2_Series_Bureau.Models;
using TP2_Series_Bureau.Services;
using TP2_Series_Bureau.Views;

namespace TP2_Series_Bureau.ViewModels
{
    public class ModifierSupprimerSerieViewModel : BaseViewModel
    {
        private readonly ISerieService _service = new WSSerieService();

        private int id;

        public int ID
        {
            get => id;
            set
            {
                id = value;
                OnPropertyChanged();
            }
        }

        public IRelayCommand BtnRechercher { get; set; }
        public IRelayCommand BtnSupprimer { get; set; }
        public IRelayCommand BtnModifier { get; set; }

        public ModifierSupprimerSerieViewModel() : base()
        {
            BtnRechercher = new RelayCommand(async () => await GetSerie());
            BtnSupprimer = new RelayCommand(async () => await DeleteSerie());
            BtnModifier = new RelayCommand(async () => await ModifierSerie());
        }

        private async Task GetSerie()
        {
            Serie? resultat = await _service.GetSerieAsync(ID);

            if (resultat is null)
            {
                await MessageAsync("Aucune série n'est assigné à cet identifiant", "Erreur");
                return;
            }

            SerieSelectionnee = resultat;
        }

        private async Task DeleteSerie()
        {
            try
            {
                await _service.DeleteSerieAsync(ID);
            }
            catch (Exception ex)
            {
                await MessageAsync("Erreur lors de la suppression :\n" + ex, "Erreur");
                return;
            }

            ID = 0;
            SerieSelectionnee = new Serie();
        }

        private async Task ModifierSerie()
        {
            try
            {
                await _service.PutSerieAsync(ID, SerieSelectionnee);
            }
            catch (Exception ex)
            {
                await MessageAsync("Erreur lors de la modification : \n" + ex, "Erreur");
                return;
            }
        }

        protected override void ChangerDePage()
        {
            App.Current.RootFrame!.Navigate(typeof(AjouterSerieView));
        }
    }
}
