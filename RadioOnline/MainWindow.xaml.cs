using RadioOnline.GetTitleMusic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace RadioOnline
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Переменная сдержащяя текущий воспроизводимый канал
        /// </summary>
        Station currentPlay { get; set; }


        /// <summary>
        /// Переменная для сворачивания приложения в трей
        /// </summary>
        NotifyIcon radioTray { get; set; }

        /// <summary>
        /// Таймер для обновления статуса песни
        /// </summary>
        DispatcherTimer timerStatus { get; set; }

        /// <summary>
        /// Таймер для получения названия песни
        /// </summary>
        DispatcherTimer timerForGetTitleMusic { get; set; }

        /// <summary>
        /// Переменная для хранения объекта парсинга. 
        /// В дальнейшем когда будет расширяться парсинги переделать по принцыпу SOLID.
        /// </summary>
        ITitleMusic TitleMusicFM { get; set; }
        
        /// <summary>
        /// Таймер для анимации названия песни
        /// </summary>
        ThicknessAnimation animation;


        private List<Station> stations = new List<Station>
        {
            new Station("Европа Plus", @"http://78.111.244.206/euro32.mp3", "https://onlineradiobox.com/ru/europaplus.ru/playlist/?cs=ru.europaplus.ru&played=1"),            
            new Station("Capital FM", @"http://icecast.vgtrk.cdnvideo.ru/capitalfmmp3?v=1608793400107", "https://onlineradiobox.com/ru/capital1053/playlist/"),
            new Station("Best FM",@"http://nashe1.hostingradio.ru/best-128.mp3","https://onlineradiobox.com/ru/best1005/playlist/?cs=ru.best1005&played=1"),            
            new Station("Monte Carlo",@"http://montecarlo.hostingradio.ru/montecarlo96.aacp","https://onlineradiobox.com/ru/montecarlo1021/playlist/?cs=ru.best1005&played=1"),
            new Station("JAZZ",@"http://nashe1.hostingradio.ru:80/jazz-128.mp3?wcid=23b1da3b-4c00-4f72-a29d-71c0637d0e11&stationId=jazz-main","https://onlineradiobox.com/ru/jazz891/playlist/?cs=ru.best1005&played=1"),
            new Station("Relax",@"http://ic4.101.ru:8000/stream/air/aac/64/200","https://onlineradiobox.com/ru/relaxfm/playlist/?cs=ru.montecarlo1021&played=1")
        };

        public MainWindow()
        {
            InitializeComponent();

            SliderVolume.Value = 0.5;

            radioTray = new NotifyIcon();
            radioTray.Icon = RadioOnline.Properties.Resources.radiov1;

            ListStations.ItemsSource = stations;

            timerStatus = new DispatcherTimer();
            timerStatus.Tick += TimerStatus_Tick;
            timerStatus.Interval = new TimeSpan(0, 0, 1);


            TitleMusicFM = new GetTitleMusicFM();
            timerForGetTitleMusic = new DispatcherTimer();
            timerForGetTitleMusic.Tick += TimerForGetTitleMusic_Tick;
            timerForGetTitleMusic.Interval = new TimeSpan(0, 0, 15);

            
            animation = new ThicknessAnimation();
            animation.From = new Thickness(300, 0, 0, 0);
            animation.To = new Thickness(-500, 0, 0, 0);
            animation.RepeatBehavior = RepeatBehavior.Forever;
            animation.Duration = new Duration(TimeSpan.Parse("0:0:10"));

            TitleMusic.BeginAnimation(TextBlock.MarginProperty, animation);

        }

        
        private void ButtonClose(object sender, RoutedEventArgs e) => this.Close();

        private void ButtonInTray(object sender, RoutedEventArgs e)
        {
            radioTray.Visible = true;
            radioTray.Text = "RadioOnline";

            radioTray.DoubleClick += (sndr, args) =>
            {
                this.Show();
                this.WindowState = WindowState.Normal;
            };
            this.Hide();
        }

        private void ButtonPlay(object sender, RoutedEventArgs e)
        {
            currentPlay = ListStations.SelectedItem as Station;

            if (currentPlay is null)
                return;

            mPlayer.Source = currentPlay.Uri;

            mPlayer.Play();

            timerStatus.Start();
            timerForGetTitleMusic.Start();

            TitleMusic.Text = TitleMusicFM.GetTitle(currentPlay.AddressTitleMusic);

        }

        private void ButtonStop(object sender, RoutedEventArgs e)
        {
            mPlayer.Stop();
            Status.Text = "Stopped !";
            TitleMusic.Text = "";
            timerForGetTitleMusic.Stop();
        }

        private void SliderVolumeChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            mPlayer.Volume = (double)SliderVolume.Value;
            PowerSound.Text = ((int)(SliderVolume.Value * 100)).ToString();
        }

        private void mPlayer_BufferingStarted(object sender, RoutedEventArgs e)
        {
            Status.Text = "Loading...";
            timerStatus.Start();
        }

        private void TimerStatus_Tick(object sender, EventArgs e)
        {
            if (mPlayer.HasAudio)
            {
                Status.Text = "Playing...";
                timerStatus.Stop();
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                this.DragMove();
        }

        private void TimerForGetTitleMusic_Tick(object sender, EventArgs e)
        {
            if (currentPlay is null)
                return;

            TitleMusic.Text = TitleMusicFM.GetTitle(currentPlay.AddressTitleMusic);
        }


    }
}