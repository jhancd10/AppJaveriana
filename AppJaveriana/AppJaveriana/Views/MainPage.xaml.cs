using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using AppJaveriana.Models;
using AppJaveriana.Services.RestAPIClient;

namespace AppJaveriana.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : MasterDetailPage
    {
        Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();
        RestClient servicioAPI;

        MenuPage menuPage;

        public MainPage(RestClient restService)
        {
            InitializeComponent();

            servicioAPI = restService;

            menuPage = new MenuPage();

            Master = menuPage;

            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(ItemsPage),servicioAPI));

            //MasterBehavior = MasterBehavior.Popover;

            MenuPages.Add((int)MenuItemType.Asignaturas, (NavigationPage)Detail);
        }

        public async Task NavigateFromMenu(int id)
        {
            if (!MenuPages.ContainsKey(id))
            {
                switch (id)
                {
                    case (int)MenuItemType.Asignaturas:
                        MenuPages.Add(id, new NavigationPage(new ItemsPage(servicioAPI)));
                        break;
                    case (int)MenuItemType.Horario:
                        MenuPages.Add(id, new NavigationPage(new AboutPage()));
                        break;
                    case (int)MenuItemType.Noticias:
                        MenuPages.Add(id, new NavigationPage(new AboutPage()));
                        break;
                }
            }

            var newPage = MenuPages[id];

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;

                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);

                IsPresented = false;
            }
        }
    }
}