﻿using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Emit;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppJaveriana.Views
{
    public class SplashPage : ContentPage
    {
        Image splashImage;

        public SplashPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);

            var sub = new AbsoluteLayout();
            splashImage = new Image
            {
                Source = "logoSplash.png",
                WidthRequest = 200,
                HeightRequest = 200
            };

            AbsoluteLayout.SetLayoutFlags(splashImage,
               AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(splashImage,
             new Rectangle(0.5, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

            sub.Children.Add(splashImage);

            this.BackgroundColor = Color.FromHex("#00008b");
            this.Content = sub;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await splashImage.ScaleTo(1, 1000); //Time-consuming processes such as initialization
            await splashImage.ScaleTo(0.9, 800, Easing.Linear);
            await splashImage.ScaleTo(150, 600, Easing.Linear);
            Application.Current.MainPage = new NavigationPage(new LoginPage()); //After loading  MainPage it gets Navigated to our new Page
        }
    }
}
