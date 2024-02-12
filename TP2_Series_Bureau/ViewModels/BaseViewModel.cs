﻿using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2_Series_Bureau.Models;
using TP2_Series_Bureau.Services;

namespace TP2_Series_Bureau.ViewModels
{
    public abstract class BaseViewModel : ObservableObject
    {
        private Serie _serieSelectionnee;
        public Serie SerieSelectionnee
        {
            get => _serieSelectionnee;
            set
            {
                _serieSelectionnee = value;
                OnPropertyChanged();
            }
        }

        protected async Task MessageAsync(string content, string title)
        {
            var messageDialog = new ContentDialog
            {
                Title = title,
                Content = content,
                CloseButtonText = "OK"
            };

            messageDialog.XamlRoot = App.MainRoot!.XamlRoot;
            await messageDialog.ShowAsync();
        }
    }
}
