﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2_Series_Bureau.Models;
using TP2_Series_Bureau.Services;

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
        public IRelayCommand BtnSupprimer { get; set; } // TODO

        public ModifierSupprimerSerieViewModel()
        {
            BtnRechercher = new RelayCommand(async () => await GetSerie());
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
            // TODO
        }
    }
}
