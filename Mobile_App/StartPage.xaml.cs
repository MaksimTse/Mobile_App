using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobile_App
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StartPage : ContentPage
    {
        public StartPage()
        {
            //InitializeComponent();
            Button Entry_btn = new Button
            {
                Text = "Entry leht",
                BackgroundColor = Color.FromHex("#C6E2FF")
            };
            Button Time_btn = new Button
            {
                Text = "Time leht",
                BackgroundColor = Color.FromHex("#C6E2FF")
            };
            Button Box_btn = new Button
            {
                Text = "Box leht",
                BackgroundColor = Color.FromHex("#C6E2FF")
            };
            StackLayout st = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                BackgroundColor = Color.FromHex("#5dd2ff")
            };
            st.Children.Add(Entry_btn);
            st.Children.Add(Time_btn);
            st.Children.Add(Box_btn);
            Content = st;
            Time_btn.Clicked += Time_btn_Clicked;
            Entry_btn.Clicked += Entry_btn_Clicked;
            Box_btn.Clicked += Box_btn_Clicked;

        }

        private async void Time_btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TimePage());
        }

        private async void Box_btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BoxPage());
        }

        private async void Entry_btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EntryPage());
        }
    }
}