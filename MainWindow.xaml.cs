using DoAn1.Controllers;
using DoAn1.Model;
using System.ComponentModel;
using System.Media;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace DoAn1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public int chedo; 
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        #region properties
        private Visibility _IsNameUser;
        public Visibility IsNameUser
        {
            get => _IsNameUser;
            set
            {
                _IsNameUser = value;
                OnPropertyChanged();
            }
        }


        private Visibility _IsQuitBoxShow;
        public Visibility IsQuitBoxShow
        {
            get => _IsQuitBoxShow;
            set
            {
                _IsQuitBoxShow = value;
                OnPropertyChanged();
            }
        }





        private bool _IsInjected;
        public bool IsInjected
        {
            get => _IsInjected;
            set
            {
                _IsInjected = value;
                OnPropertyChanged();
            }
        }
        private bool _IsImotal;
        public bool IsImotal
        {
            get => _IsImotal;
            set
            {
                _IsImotal = value;
                OnPropertyChanged();
            }
        }


        SoundPlayer sp_active;
        SoundPlayer sp_hover;
        SoundPlayer sp_megaman;
        SoundPlayer sp_congtac;
        SoundPlayer sp_hover1;
        #endregion

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            FirstLoad();
            
            
        }
        
        #region methods
        void FirstLoad()
        {
            IsInjected = false;
            IsQuitBoxShow = Visibility.Hidden;
            IsNameUser = Visibility.Hidden;
            LoadSound();
            easy.Visibility = Visibility.Hidden;
            hard.Visibility = Visibility.Hidden;
            phaichonmode.Visibility = Visibility.Hidden;
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
        #endregion


        #region events
        private void DockPanel_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            this.DragMove();
        }

        private void Image_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Image_PreviewMouseDown_1(object sender, MouseButtonEventArgs e)
        {
            PlaySoundCongTac();
            IsQuitBoxShow = Visibility.Visible;
        }



        private void Image_MouseDown_Imotal(object sender, MouseButtonEventArgs e)
        {
            IsImotal = !IsImotal;
            PlaySoundActive();
            IsNameUser = Visibility.Visible;
            easy.Visibility = Visibility.Visible;
            hard.Visibility = Visibility.Visible;
 
        }

        private void Image_MouseEnter_Imotal(object sender, MouseEventArgs e)
        {
            if (!IsImotal)
                PlaySoundHover();
        }

        #endregion

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            PlaySoundCongTac();
            this.Close();
            
        }

        private void TextBlock_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            PlaySoundCongTac();
            IsQuitBoxShow = Visibility.Hidden;
            
        }
        Diem nguoichoi = new Diem();
        private void TextBlock_MouseDown_2(object sender, MouseButtonEventArgs e)
        {
            PlaySoundCongTac();

            if (easy.IsChecked == true)
            {
                chedo = 0;
                nguoichoi.NameUser = TenUser.Text;
                nguoichoi.Score = null;
                DiemController.ThemUser(nguoichoi);
                Game game = new Game(nguoichoi, chedo);
                game.Show();
                this.Close();
            }
            else if(hard.IsChecked == true)
            {
                chedo = 1;
                nguoichoi.NameUser = TenUser.Text;
                nguoichoi.Score = null;
                DiemController.ThemUser(nguoichoi);
                Game game = new Game(nguoichoi, chedo);
                game.Show();
                this.Close();
            }
            else
            {
                phaichonmode.Visibility = Visibility.Visible;
            }    

        }

        private void TextBlock_MouseDown_3(object sender, MouseButtonEventArgs e)
        {
            PlaySoundCongTac();
            IsNameUser = Visibility.Hidden;
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }
    }

}
