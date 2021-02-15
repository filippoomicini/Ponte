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
        public MainWindow()
        {
            Thread t1 = new Thread(new ThreadStart(MovimentoMacchina1));
            Thread t2 = new Thread(new ThreadStart(MovimentoMacchina2));
            t1.Start();
            t2.Start();

        }

        public void MovimentoMacchina1()
        {
            lock (x)
            {
                int a = rnd.Next(0, 20);
                if (a > 10)
                {
                    //movimento macchina1
                }
            }
        }

        public void MovimentoMacchina2()
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
