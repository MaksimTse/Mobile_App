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
    public partial class BoxPage : ContentPage
    {
        private Random random = new Random();

        public BoxPage()
        {
            InitializeComponent();

            var box = new BoxView
            {
                WidthRequest = 100,
                HeightRequest = 100,
                BackgroundColor = GetRandomColor()
            };

            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += TapGestureRecognizer_Tapped;
            box.GestureRecognizers.Add(tapGestureRecognizer);

            var stackLayout = new StackLayout
            {
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Children =
                {
                    box,
                }
            };

            Content = stackLayout;
        }
        int count;
        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var boxView = (BoxView)sender;
            boxView.BackgroundColor = GetRandomColor();
            boxView.WidthRequest *= 1.2;
            boxView.HeightRequest *= 1.2;
            count += 1;
            if (count == 8)
            {
                boxView.WidthRequest = 100;
                boxView.HeightRequest = 100;
                count = 0;
            }
        }

        private Color GetRandomColor()
        {
            return Color.FromRgb(random.Next(256), random.Next(256), random.Next(256));
        }
    }
}