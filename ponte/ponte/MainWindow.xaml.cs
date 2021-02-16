using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Threading;

namespace ponte
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static object x = new object();
        Random rnd = new Random();
        int mASinistro = 586;
        int mADestro = -132;
        int mVSinistro = -140;
        int mVDestro = 507;
        public MainWindow()
        {
            InitializeComponent();
            Thread t1 = new Thread(new ThreadStart(MovimentoMacchinaA));
            Thread t2 = new Thread(new ThreadStart(MovimentoMacchinaV));
            while(macchinaA.Margin != new Thickness(104,30,558,138) && macchinaV.Margin != new Thickness(530,66,164,123))
            {
                t1.Start();
                t2.Start();
            }

        }

        public void MovimentoMacchinaA()
        {
            lock (x)
            {
                int a = rnd.Next(0, 20);
                if (a > 10)
                {
                    mASinistro = mASinistro - 10;
                    mADestro = mADestro + 10;
                    macchinaA.Margin = new Thickness(mASinistro, 30, mADestro, 138);
                    if (macchinaA.Margin == new Thickness(430, 30, 24, 138))
                    {
                        semaforoVerdeA.Visibility = Visibility.Visible;
                        semaforoRossoV.Visibility = Visibility.Visible;
                        int mASinistro2 = 430;
                        int mADestro2 = 24;
                        while (macchinaA.Margin != new Thickness(10, 30, 444, 138))
                        {
                            mASinistro2 = mASinistro2 - 10;
                            mADestro2 = mADestro2 + 10;
                            macchinaA.Margin = new Thickness(mASinistro2, 30, mADestro2, 138);

                        }
                        semaforoVerdeA.Visibility = Visibility.Hidden;
                        semaforoVerdeV.Visibility = Visibility.Visible;
                        semaforoRossoA.Visibility = Visibility.Visible;
                        semaforoRossoV.Visibility = Visibility.Hidden;
                    }
                }
            }
        }

        public void MovimentoMacchinaV()
        {
            lock (x)
            {
                int a = rnd.Next(0, 20);
                if (a > 10)
                {
                    mVSinistro = mVSinistro + 10;
                    mVDestro = mVDestro - 10;
                    macchinaV.Margin = new Thickness(mVSinistro, 66, mVDestro, 123);
                    if (macchinaV.Margin == new Thickness(-28, 66, 394, 123))
                    {
                        semaforoVerdeV.Visibility = Visibility.Visible;
                        semaforoRossoA.Visibility = Visibility.Visible;
                        int mVSinistro2 = -28;
                        int mVDestro2 = 394;
                        while (macchinaV.Margin != new Thickness(378, 66, 12, 123))
                        {
                            mVSinistro2 = mVSinistro2 + 10;
                            mVDestro2 = mVDestro2 - 10;
                            macchinaV.Margin = new Thickness(mVSinistro2, 66, mVDestro2, 123);

                        }
                        semaforoVerdeV.Visibility = Visibility.Hidden;
                        semaforoVerdeA.Visibility = Visibility.Visible;
                        semaforoRossoV.Visibility = Visibility.Visible;
                        semaforoRossoA.Visibility = Visibility.Hidden;
                    }
                }
            }
        }
    }
}



