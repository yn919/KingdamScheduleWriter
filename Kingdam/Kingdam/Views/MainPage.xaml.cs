﻿using Kingdam.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Kingdam.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private MainViewModel MainViewModel;

        public MainPage()
        {
            InitializeComponent();
            MainViewModel = new MainViewModel();
            MainViewModel.Start();

            this.BindingContext = MainViewModel;
        }
    }
}
