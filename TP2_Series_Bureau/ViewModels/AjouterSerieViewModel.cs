using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml.Controls;
using TP2_Series_Bureau.Models;
using TP2_Series_Bureau.Services;

namespace TP2_Series_Bureau.ViewModels
{
    public class AjouterSerieViewModel : BaseViewModel
    {
        public IRelayCommand BtnAjouterSerie { get; }

        public AjouterSerieViewModel()
        {
            SerieSelectionnee = new Serie();
            BtnAjouterSerie = new RelayCommand(async () => await AjouterSerie());
        }

        private async Task AjouterSerie()
        {
            var stringsAVerifier = new string[]
            {
                SerieSelectionnee.Titre,
                SerieSelectionnee.Resume,
                SerieSelectionnee.Network
            };

            if (stringsAVerifier.Any(x => string.IsNullOrEmpty(x)))
            {
                await MessageAsync("Vous devez remplir tous les champs.", "Erreur");
                return;
            }

            var intsAVerifier = new int[]
            {
                SerieSelectionnee.Nbsaisons,
                SerieSelectionnee.Nbepisodes,
                SerieSelectionnee.Anneecreation
            };

            if (intsAVerifier.Any(x => x <= 0))
            {
                await MessageAsync("Aucune valeur ne peut être nulle ou négative.", "Erreur");
                return;
            }

            ISerieService service = new WSSerieService();

            try
            {
                await service.PostSerieAsync(SerieSelectionnee);
            }
            catch (HttpRequestException ex)
            {
                await MessageAsync("La requête a échouée.\nMessage d'erreur :\n" + ex, "Erreur");
            }
        }
    }
}
