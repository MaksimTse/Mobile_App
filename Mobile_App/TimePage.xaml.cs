using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobile_App
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TimePage : ContentPage
    {
        private ProgressBar secondsProgressBar;
        private ProgressBar minutesProgressBar;

        public TimePage()
        {
            InitializeComponent();

            // Создаем ProgressBar для секунд
            secondsProgressBar = new ProgressBar
            {
                Progress = 0,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            // Создаем ProgressBar для минут
            minutesProgressBar = new ProgressBar
            {
                Progress = 0,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            var stackLayout = new StackLayout
            {
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Children =
                {
                    new Button
                    {
                        Text = "Naita Aeg",
                        Margin = new Thickness(0, 20, 0, 0),
                        Command = new Command(() =>
                        {
                            if (flag)
                            {
                                flag = false;
                            }
                            else
                            {
                                flag = true;
                                NaitaAeg();
                            }
                        })
                    },
                    Time_run,
                    lbl,
                    secondsProgressBar,
                    minutesProgressBar
                }
            };

            Content = stackLayout;
        }

        bool flag = false;

        public async void NaitaAeg()
        {
            while (flag)
            {
                DateTime now = DateTime.Now;
                double secondsProgress = now.Second / 60.0; // Прогресс для секунд
                double minutesProgress = (now.Minute + secondsProgress) / 60.0; // Прогресс для минут

                // Обновляем ProgressBar для секунд и минут
                secondsProgressBar.Progress = secondsProgress;
                minutesProgressBar.Progress = minutesProgress;

                Time_run.Text = now.ToString("F");
                lbl.Text = now.ToString("f");
                await Task.Delay(1000);
            }
        }

        private void Time_run_Clicked(object sender, EventArgs e)
        {
            if (flag)
            {
                flag = false;
            }
            else
            {
                flag = true;
                NaitaAeg();
            }
        }
    }
}