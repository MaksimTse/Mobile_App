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
    public partial class EntryPage : ContentPage
    {
        Label lbl;
        Editor editor;

        public EntryPage()
        {
            InitializeComponent();

            Button Close_btn = new Button
            {
                Text = "Tagasi",
                BackgroundColor = Color.FromHex("#C6E2FF")
            };

            lbl = new Label
            {
                Text = "Example",
                BackgroundColor = Color.Aqua,
                TextColor = Color.FromHex("#000000")
            };
            editor = new Editor
            {
                Placeholder = "Sisesta siia tekst...",
                HorizontalOptions = LayoutOptions.Center,
            };
            StackLayout st = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                BackgroundColor = Color.FromHex("#5dd2ff"),
                Children = { lbl, editor, Close_btn },
                VerticalOptions = LayoutOptions.End,
            };
            Content = st;
            editor.TextChanged += Editor_TextChanged;
            Close_btn.Clicked += Close_btn_Clicked;
        }

        private void Editor_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (editor.Text.ToLower() == "admin")
            {
                lbl.Text = "Tere admin! Kuidas ma saan teid aidata?";
            }
            else
            {
                lbl.Text = editor.Text;
            }
        }

        private async void Close_btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}