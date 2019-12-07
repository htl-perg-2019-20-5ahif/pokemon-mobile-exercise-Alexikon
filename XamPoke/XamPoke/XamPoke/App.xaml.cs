﻿using Xamarin.Forms;

namespace XamPoke
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new PokemonListPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
