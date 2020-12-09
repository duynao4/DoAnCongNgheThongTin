using DoAn1.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Media;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DoAn1
{
    /// <summary>
    /// Interaction logic for WinGame.xaml
    /// </summary>
    public partial class WinGame : Window
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public int chedo;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        private bool _IsWinGame;
        public bool IsWinGame
        {
            get => _IsWinGame;
            set
            {
                _IsWinGame = value;
                OnPropertyChanged();
            }
        }
        SoundPlayer sp_active;
        SoundPlayer sp_hover;
        SoundPlayer sp_megaman;
        SoundPlayer sp_congtac;
        SoundPlayer sp_hover1;
        Diem nguoichoi = new Diem();
        public WinGame(int sodiem, Diem nguoichoi,int chedo)
        {
            InitializeComponent();
            this.DataContext = this;
            this.nguoichoi = nguoichoi;
            this.chedo = chedo;
            LoadSound();
            if (sodiem > 0)
            {
                winscore.Text = winscore.Text + " " + Convert.ToString(sodiem);
                video.Source = new Uri(@"D:\Học Kỳ 1- Năm 3\Đồ án CNTT\DoAn1\Video\WinGame.mp4");
                winscore.Visibility = Visibility.Visible;
                losescore.Visibility = Visibility.Hidden;
            }
            else
            {
                losescore.Text = losescore.Text;
                video.Source = new Uri(@"D:\Học Kỳ 1- Năm 3\Đồ án CNTT\DoAn1\Video\LoseGame.mp4");
                losescore.Visibility = Visibility.Visible;
                winscore.Visibility = Visibility.Hidden;
            }
        }

        void LoadSound()
        {
            sp_active = new SoundPlayer(Properties.Resources.hover_2);
            sp_hover = new SoundPlayer(Properties.Resources.hover);
            sp_megaman = new SoundPlayer(Properties.Resources.megaman);
            sp_congtac = new SoundPlayer(Properties.Resources.congtac);
            sp_hover1 = new SoundPlayer(Properties.Resources.hover_3);


        }
        void PlaySoundCongTac()
        {
            sp_congtac.Play();
        }
        void PlaySoundActive()
        {
            sp_active.Play();
        }

        void PlaySoundHover()
        {
            sp_hover.Play();
        }
        void PlaySoundHover1()
        {
            sp_hover1.Play();
        }
        private void Image_MouseDown_WinGame(object sender, MouseButtonEventArgs e)
        {
            IsWinGame = !IsWinGame;
            PlaySoundActive();
            //MainWindow mainwindow = new MainWindow();
            //mainwindow.Show();
            Game game = new Game(nguoichoi,chedo);
            game.Show();
            this.Close();
        }
        private void Image_MouseEnter_WinGame(object sender, MouseEventArgs e)
        {
            if (!IsWinGame)
                PlaySoundHover();

        }
        private void DockPanel_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            this.DragMove();

        }
        private void Image_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void Image_PreviewMouseDown_1(object sender, MouseButtonEventArgs e)
        {

        }

    }
}
