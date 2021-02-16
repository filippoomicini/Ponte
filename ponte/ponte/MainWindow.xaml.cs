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
        int mV = -140;
        int mASinistro = 586;
        int mADestro = -132;

        public MainWindow()
        {
            Thread t1 = new Thread(new ThreadStart(MovimentoMacchinaA));
            Thread t2 = new Thread(new ThreadStart(MovimentoMacchinaV));
            t1.Start();
            t2.Start();

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
                    if(macchinaA.Margin == new Thickness(430, 30, 24, 138))
                    {
                        semaforoVerdeA.Visibility = Visibility.Visible;
                        semaforoRossoV.Visibility = Visibility.Visible;
                        int mASinistro2 = 430;
                        int mADestro2 = 138;
                        while(macchinaA.Margin != new Thickness(10, 30, 444, 138))
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
                    //movimento macchina2
                }
            }
        }
    }
}
