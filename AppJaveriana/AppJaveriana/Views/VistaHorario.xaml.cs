using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppJaveriana.Services.RestAPIClient;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppJaveriana.Views
{
    public partial class VistaHorario : ContentPage
    {

        private Dictionary<string, int> hora = new Dictionary<string, int>();
        private string changeButtom;
        RestClient servicioAPI;
        public VistaHorario(RestClient restService)
        {
            InitializeComponent();
            servicioAPI = restService;

            string hour = "7";
            string minut = "00";
            for (int i = 0; i < 32; i++)
            {
                hora.Add(hour + ":" + minut, i + 1);

                if ((i % 2 == 0 && i != 0) || i == 1)
                {
                    var camb = int.Parse(hour);
                    camb += 1;
                    hour = Convert.ToString(camb);
                }
                if (minut == "00")
                {
                    minut = "30";
                }
                else
                {
                    minut = "00";
                }
            }



            Grid grid = new Grid
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                Margin = new Thickness(10),
                RowDefinitions =
                {
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto }
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition { Width = GridLength.Auto },
                    new ColumnDefinition {  Width = GridLength.Auto },
                    new ColumnDefinition { Width = GridLength.Auto },
                    new ColumnDefinition {  Width = GridLength.Auto },
                    new ColumnDefinition { Width = GridLength.Auto },
                    new ColumnDefinition { Width = GridLength.Auto },
                    new ColumnDefinition {  Width = GridLength.Auto }
                }
            };

            grid.Children.Add(new Label
            {
                Text = "Lun",
                HorizontalOptions = LayoutOptions.FillAndExpand
            }, 1, 0);

            grid.Children.Add(new Label
            {
                Text = "Mar",
                HorizontalOptions = LayoutOptions.FillAndExpand
            }, 2, 0);

            grid.Children.Add(new Label
            {
                Text = "Mie",
                HorizontalOptions = LayoutOptions.FillAndExpand
            }, 3, 0);

            grid.Children.Add(new Label
            {
                Text = "Jue",
                HorizontalOptions = LayoutOptions.FillAndExpand
            }, 4, 0);

            grid.Children.Add(new Label
            {
                Text = "Vie",
                HorizontalOptions = LayoutOptions.FillAndExpand
            }, 5, 0);

            grid.Children.Add(new Label
            {
                Text = "Sab",
                HorizontalOptions = LayoutOptions.FillAndExpand
            }, 6, 0);

            grid.Children.Add(new Label
            {
                Text = "7:00",

            }, 0, hora["7:00"]);

            grid.Children.Add(new Label
            {
                Text = "7:30",

            }, 0, hora["7:30"]);
            grid.Children.Add(new Label
            {
                Text = "8:00",

            }, 0, 3);
            grid.Children.Add(new Label
            {
                Text = "8:30",

            }, 0, 4);
            grid.Children.Add(new Label
            {
                Text = "9:00",

            }, 0, 5);
            grid.Children.Add(new Label
            {
                Text = "9:30",

            }, 0, 6);
            grid.Children.Add(new Label
            {
                Text = "10:00",

            }, 0, 7);
            grid.Children.Add(new Label
            {
                Text = "10:30",

            }, 0, 8);
            grid.Children.Add(new Label
            {
                Text = "11:00",
            }, 0, 9);
            grid.Children.Add(new Label
            {
                Text = "11:30",
            }, 0, 10);
            grid.Children.Add(new Label
            {
                Text = "12:00",
            }, 0, 11);
            grid.Children.Add(new Label
            {
                Text = "12:30",
            }, 0, 12);
            grid.Children.Add(new Label
            {
                Text = "13:00",
            }, 0, 13);
            grid.Children.Add(new Label
            {
                Text = "13:30",
            }, 0, 14);
            grid.Children.Add(new Label
            {
                Text = "14:00",
            }, 0, 15);
            grid.Children.Add(new Label
            {
                Text = "14:30",
            }, 0, 16);
            grid.Children.Add(new Label
            {
                Text = "15:00",
            }, 0, 17);
            grid.Children.Add(new Label
            {
                Text = "15:30",
            }, 0, 18);
            grid.Children.Add(new Label
            {
                Text = "16:00",
            }, 0, 19);
            grid.Children.Add(new Label
            {
                Text = "16:30",
            }, 0, 20);
            grid.Children.Add(new Label
            {
                Text = "17:00",
            }, 0, 21);
            grid.Children.Add(new Label
            {
                Text = "17:30",
            }, 0, 22);
            grid.Children.Add(new Label
            {
                Text = "18:00",
            }, 0, 23);
            grid.Children.Add(new Label
            {
                Text = "18:30",
            }, 0, 24);
            grid.Children.Add(new Label
            {
                Text = "19:00",
            }, 0, 25);
            grid.Children.Add(new Label
            {
                Text = "19:30",
            }, 0, 26);
            grid.Children.Add(new Label
            {
                Text = "20:00",
            }, 0, 27);
            grid.Children.Add(new Label
            {
                Text = "20:30",
            }, 0, 28);
            grid.Children.Add(new Label
            {
                Text = "21:00",
            }, 0, 29);
            grid.Children.Add(new Label
            {
                Text = "21:30",
            }, 0, 30);
            grid.Children.Add(new Label
            {
                Text = "22:00",
            }, 0, 31);
            grid.Children.Add(new Label
            {
                Text = "22:30",
            }, 0, 32);

            for (var i = 1; i < 33; i++)
            {
                for (var j = 1; j < 7; j++)
                {
                    grid.Children.Add(new StackLayout
                    {

                        BackgroundColor = Color.LightGray,
                        Children =
                        {
                            new Label
                            {
                                TextColor = Color.Black,
                            }
                        }
                    }, j, i);
                }
            }
            Button boton = new Button
            {
                Text = "Mov",
            };
            boton.Pressed += OnButtonClicked;
            grid.Children.Add(new StackLayout
            {

                BackgroundColor = Color.LightGray,
                Children =
                        {
                            new Label
                            {
                                TextColor = Color.Black,
                            },
                            boton,
                        }
            }, 1, 1);
            ScrollView scrollView = new ScrollView
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Content = grid
            };
            // Build the page.
            Title = "Grid Demo";
            Content = scrollView;
        }
        public string ChangeButtom
        {
            get { return changeButtom; }
            set
            {
                changeButtom = value;
                OnPropertyChanged();
            }
        }
        public void OnButtonClicked(object sender, EventArgs args)
        {
            //string changeButtom = "Materia";
        }
    }
}