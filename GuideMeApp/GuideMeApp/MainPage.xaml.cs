﻿using GuideMeApp.ViewModels;

namespace GuideMeApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }
    }

}
