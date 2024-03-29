﻿
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamPoke
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailPage : ContentPage
    {
        public Pokemon Pokemon { get; set; }

        public DetailPage(Pokemon details)
        {
            InitializeComponent();

            Pokemon = details;

            BindingContext = this;
        }
    }
}