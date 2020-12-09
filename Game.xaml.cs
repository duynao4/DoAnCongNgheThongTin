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
using System.Windows.Navigation;
using System.Windows.Shapes;
using DoAn1.Model;
using DoAn1.Controllers;
namespace DoAn1
{
    /// <summary>
    /// Interaction logic for Game.xaml
    /// </summary>
    public partial class Game : Window, INotifyPropertyChanged
    {
        public int solan = 1;
        public int sodiem = 0;
        public int dapan;
        public int dapanlantruoc= -1;
        public int so = 20;
        SoundPlayer sp_active;
        SoundPlayer sp_hover;
        SoundPlayer sp_megaman;
        SoundPlayer sp_wrong;
        SoundPlayer sp_congtac;
        SoundPlayer sp_hover1;
        public int chedo;

        public event PropertyChangedEventHandler PropertyChanged;
        
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
        void LoadSound()
        {
            sp_active = new SoundPlayer(Properties.Resources.hover_2);
            sp_hover = new SoundPlayer(Properties.Resources.hover);
            sp_megaman = new SoundPlayer(Properties.Resources.megaman);
            sp_wrong = new SoundPlayer(Properties.Resources.wrong);
            sp_congtac = new SoundPlayer(Properties.Resources.congtac);
            sp_hover1 = new SoundPlayer(Properties.Resources.hover_3);


        }

        void PlaySoundActive()
        {
            sp_active.Play();
        }
        void PlaySoundCongTac()
        {
            sp_congtac.Play();
        }
        void PlaySoundHover()
        {
            sp_hover.Play();
        }
        void PlaySoundHover1()
        {
            sp_hover1.Play();
        }
        void PlaySoundWrong()
        {
            sp_wrong.Play();
        }
        private Visibility _IsQuitBoxShow1;
        public Visibility IsQuitBoxShow1
        {
            get => _IsQuitBoxShow1;
            set
            {
                _IsQuitBoxShow1 = value;
                OnPropertyChanged();
            }
        }
        private Visibility _IsMode;
        public Visibility IsMode
        {
            get => _IsMode;
            set
            {
                _IsMode = value;
                OnPropertyChanged();
            }
        }
        private bool _IsChangeMode;
        public bool IsChangeMode
        {
            get => _IsChangeMode;
            set
            {
                _IsChangeMode = value;
                OnPropertyChanged();
            }
        }


        Diem nguoichoi = new Diem();

        public Game(Diem nguoichoi,int chedo)
        {

            InitializeComponent();
            this.nguoichoi = nguoichoi;
            FirstLoad();
            txbnguoichoi.Text = "Hello " + nguoichoi.NameUser + " Score 100";
            luot1.Visibility = Visibility.Visible;
            luot2.Visibility = Visibility.Visible;
            luot3.Visibility = Visibility.Visible;
            luot4.Visibility = Visibility.Visible;
            luot5.Visibility = Visibility.Visible;
            luot6.Visibility = Visibility.Visible;
            luot7.Visibility = Visibility.Visible;
            luot8.Visibility = Visibility.Visible;
            luot9.Visibility = Visibility.Visible;
            luot10.Visibility = Visibility.Visible;
            this.chedo = chedo;
            IsMode = Visibility.Hidden;
            this.DataContext = this;
            easy.Visibility = Visibility.Hidden;
            hard.Visibility = Visibility.Hidden;


            //txblsoluotdi.Text = "Number Of Pass 1";

            //ImageBrush backgr = new ImageBrush();
            //backgr.ImageSource = new BitmapImage(new Uri("images/freljord2.jpg", UriKind.RelativeOrAbsolute));
            //this.Background = backgr;


        }
        void FirstLoad()
        {
            IsQuitBoxShow1 = Visibility.Hidden;
            LoadSound();
            this.DataContext = this;

        }
        private void DockPanel_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            this.DragMove();

        }

        private void Image_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            PlaySoundCongTac();
            IsQuitBoxShow1 = Visibility.Visible;
        }

        private void Image_PreviewMouseDown_1(object sender, MouseButtonEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }


        private void txbnhapso_KeyDown(object sender, KeyEventArgs e)
        {

            //txblsoluotdi.Text = "Number Of Pass " + solan.ToString();
            if (e.Key == Key.Enter && chedo==1)
            {

               
                dapan = Convert.ToInt32(txbnhapso.Text.Trim());
                if (dapan == so && solan == 1)
                {
                    sodiem = 100;
                    if (sodiem > Convert.ToInt32(nguoichoi.Score))
                    {
                        nguoichoi.Score = sodiem;
                        DiemController.UpdateUser(nguoichoi);
                    }
                    WinGame wingame = new WinGame(sodiem, nguoichoi, chedo);
                    wingame.Show();
                    this.Close();
                }
                else if (dapan == so && solan<=10)
                {
                    if (sodiem> Convert.ToInt32( nguoichoi.Score))
                    {
                        nguoichoi.Score = sodiem;
                        DiemController.UpdateUser(nguoichoi);
                    }
                    WinGame wingame = new WinGame(sodiem,nguoichoi,chedo);
                    wingame.Show();
                    this.Close();
                }
                else if(solan==10 && dapan!=so)
                {
                    sodiem = 0;
                    if (nguoichoi.Score==null)
                    {
                        nguoichoi.Score = sodiem;
                        DiemController.UpdateUser(nguoichoi);
                    }
                    WinGame wingame = new WinGame(sodiem,nguoichoi,chedo);
                    wingame.Show();
                    this.Close();
                }    
                else if(dapanlantruoc != dapan && solan<=10 && dapan!=so)
                {
                    PlaySoundWrong();
                    if (solan == 1)
                    {
                        luot1.Visibility = Visibility.Hidden;
                    }
                    else if (solan == 2)
                    {
                        luot2.Visibility = Visibility.Hidden;
                    }
                    else if (solan == 3)
                    {
                        luot3.Visibility = Visibility.Hidden;
                    }
                    else if (solan == 4)
                    {
                        luot4.Visibility = Visibility.Hidden;
                    }
                    else if (solan == 5)
                    {
                        luot5.Visibility = Visibility.Hidden;
                    }
                    else if (solan == 6)
                    {
                        luot6.Visibility = Visibility.Hidden;
                    }
                    else if (solan == 7)
                    {
                        luot7.Visibility = Visibility.Hidden;
                    }
                    else if (solan == 8)
                    {
                        luot8.Visibility = Visibility.Hidden;
                    }
                    else if (solan == 9)
                    {
                        luot9.Visibility = Visibility.Hidden;
                    }
                    else if (solan == 10)
                    {
                        luot10.Visibility = Visibility.Hidden;
                    }
                    solan = solan + 1;
                    if (solan == 1)
                    {
                        sodiem = 100;
                    }
                    else if (solan == 2)
                    {
                        sodiem = 95;
                    }
                    else if (solan == 3)
                    {
                        sodiem = 90;
                    }
                    else if (solan == 4)
                    {
                        sodiem = 80;
                    }
                    else if (solan == 5)
                    {
                        sodiem = 70;
                    }
                    else if (solan == 6)
                    {
                        sodiem = 60;
                    }
                    else if (solan == 7)
                    {
                        sodiem = 50;
                    }
                    else if (solan == 8)
                    {
                        sodiem = 40;
                    }
                    else if (solan == 9)
                    {
                        sodiem = 30;
                    }
                    else if (solan == 10)
                    {
                        sodiem = 20;
                    }
                    txbnguoichoi.Text = "Hello " + nguoichoi.NameUser +" Score "+Convert.ToString(sodiem);
                    dapanlantruoc = dapan;
                   
                    if (dapan < so)
                    {
                        txblgoiy.Text = "Your Number Is Smaller Than The Answer";
                    }
                    else
                    {
                        txblgoiy.Text = "Your Number Is Larger Than The Answer";
                    }
                }
                else if(dapan==dapanlantruoc && dapan!=so && solan<=10)
                {
                    PlaySoundHover1();
                    txbnguoichoi.Text = "Hello " + nguoichoi.NameUser + " Score " + Convert.ToString(sodiem);
                    txblgoiy.Text = "You Have Entered The Same Number";
                }
            }
            else if (e.Key == Key.Enter && chedo == 0)
            {


                dapan = Convert.ToInt32(txbnhapso.Text.Trim());

                if (dapan == so && solan == 1)
                {
                    sodiem = 100;
                    if (sodiem > Convert.ToInt32(nguoichoi.Score))
                    {
                        nguoichoi.Score = sodiem;
                        DiemController.UpdateUser(nguoichoi);
                    }
                    WinGame wingame = new WinGame(sodiem, nguoichoi, chedo);
                    wingame.Show();
                    this.Close();
                }
                else if (dapan == so && solan <= 10)
                {
                    if (sodiem > Convert.ToInt32(nguoichoi.Score))
                    {
                        nguoichoi.Score = sodiem;
                        DiemController.UpdateUser(nguoichoi);
                    }
                    WinGame wingame = new WinGame(sodiem, nguoichoi, chedo);
                    wingame.Show();
                    this.Close();
                }
                else if (solan == 10 && dapan != so)
                {
                    sodiem = 0;
                    if (nguoichoi.Score == null)
                    {
                        nguoichoi.Score = sodiem;
                        DiemController.UpdateUser(nguoichoi);
                    }
                    WinGame wingame = new WinGame(sodiem, nguoichoi, chedo);
                    wingame.Show();
                    this.Close();
                }
                else if (dapanlantruoc != dapan && solan <= 10 && dapan != so)
                {
                    PlaySoundWrong();
                    if (solan == 1)
                    {
                        luot1.Visibility = Visibility.Hidden;
                    }
                    else if (solan == 2)
                    {
                        luot2.Visibility = Visibility.Hidden;
                    }
                    else if (solan == 3)
                    {
                        luot3.Visibility = Visibility.Hidden;
                    }
                    else if (solan == 4)
                    {
                        luot4.Visibility = Visibility.Hidden;
                    }
                    else if (solan == 5)
                    {
                        luot5.Visibility = Visibility.Hidden;
                    }
                    else if (solan == 6)
                    {
                        luot6.Visibility = Visibility.Hidden;
                    }
                    else if (solan == 7)
                    {
                        luot7.Visibility = Visibility.Hidden;
                    }
                    else if (solan == 8)
                    {
                        luot8.Visibility = Visibility.Hidden;
                    }
                    else if (solan == 9)
                    {
                        luot9.Visibility = Visibility.Hidden;
                    }
                    else if (solan == 10)
                    {
                        luot10.Visibility = Visibility.Hidden;
                    }
                    solan = solan + 1;
                    if (solan == 1)
                    {
                        sodiem = 100;
                    }
                    else if (solan == 2)
                    {
                        sodiem = 95;
                    }
                    else if (solan == 3)
                    {
                        sodiem = 90;
                    }
                    else if (solan == 4)
                    {
                        sodiem = 80;
                    }
                    else if (solan == 5)
                    {
                        sodiem = 70;
                    }
                    else if (solan == 6)
                    {
                        sodiem = 60;
                    }
                    else if (solan == 7)
                    {
                        sodiem = 50;
                    }
                    else if (solan == 8)
                    {
                        sodiem = 40;
                    }
                    else if (solan == 9)
                    {
                        sodiem = 30;
                    }
                    else if (solan == 10)
                    {
                        sodiem = 20;
                    }
                    txbnguoichoi.Text = "Hello " + nguoichoi.NameUser + " Score " + Convert.ToString(sodiem);
                    dapanlantruoc = dapan;

                    if (dapan < so)
                    {
                        txblgoiy.Text = "Your Number Is Smaller Than The Answer. The Answer About 30 - 40";
                    }
                    else
                    {
                        txblgoiy.Text = "Your Number Is Larger Than The Answer. The Answer about 30 - 40";
                    }
                }
                else if (dapan == dapanlantruoc && dapan != so && solan <= 10)
                {
                    PlaySoundHover1();
                    txbnguoichoi.Text = "Hello " + nguoichoi.NameUser + " Score " + Convert.ToString(sodiem);
                    txblgoiy.Text = "You Have Entered The Same Number";
                }
            }
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            PlaySoundCongTac();
            this.Close();

        }

        private void TextBlock_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            PlaySoundCongTac();
            IsQuitBoxShow1 = Visibility.Hidden;
        }


        private void TextBlock_MouseDown_2(object sender, MouseButtonEventArgs e)
        {
            PlaySoundCongTac();
            if (easy.IsChecked == true)
            {
                chedo = 0;
            }
            else
            {
                chedo = 1;
            }
            IsMode = Visibility.Hidden;
            easy.Visibility = Visibility.Hidden;
            hard.Visibility = Visibility.Hidden;
        }

        private void TextBlock_MouseDown_3(object sender, MouseButtonEventArgs e)
        {
            PlaySoundCongTac();
            IsMode = Visibility.Hidden;
            easy.Visibility = Visibility.Hidden;
            hard.Visibility = Visibility.Hidden;
        }

        private void Image_MouseDown_IsChangeMode(object sender, MouseButtonEventArgs e)
        {
            PlaySoundActive();
            if (chedo == 0)
            {
                easy.IsChecked = true;
            }
            else
            {
                hard.IsChecked = true;
            }
            IsMode = Visibility.Visible;
            easy.Visibility = Visibility.Visible;
            hard.Visibility = Visibility.Visible;
        }
        private void Image_MouseEnter_IsChangeMode(object sender, MouseEventArgs e)
        {
        }
    }

}
