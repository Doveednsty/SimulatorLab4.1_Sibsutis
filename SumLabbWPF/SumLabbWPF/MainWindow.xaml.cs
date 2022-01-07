using LiveCharts;
using LiveCharts.Helpers;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SumLabbWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Счетчики
        int l1 = 0;
        int m1 = 0;
        int p1 = 0;
        int b1 = 0;
        int y1 = 0;
        int x1 = 0;
        int z1 = 0;

        int l2 = 0;
        int m2 = 0;
        int p2 = 0;
        int b2 = 0;
        int y2 = 0;
        int x2 = 0;
        int z2 = 0;

        int l3 = 0;
        int m3 = 0;
        int p3 = 0;
        int b3 = 0;
        int y3 = 0;
        int x3 = 0;
        int z3 = 0;


        int UaClickCount = 0;
        int IcClickCount = 0;

        // /Счетчики

        // Процесс изменения положения (угла) стрелки каждого прибора
        RotateTransform rotateTransform1 = new RotateTransform(-57); // ротация Ic
        RotateTransform rotateTransform2 = new RotateTransform(-55); // ротация Ia
        RotateTransform rotateTransform3 = new RotateTransform(3.5); // ротация Ua

        List<double> Ua = new List<double>() { 16, 17, 18, 19, 20, 21, 22 };
        List<double> Imax = new List<double>() { 2, 1.833, 1.666, 1.499, 1.333, 1.166, 1 };
        List<double> Imin = new List<double>() { 0.7, 0.633, 0.566, 0.5, 0.433, 0.366, 0.3 };
        List<double> Ickr = new List<double>();

        double em = 1.76 * Math.Pow(10, 4);
        double l = 0.1;
        double Ra = 5 * Math.Pow(10, -3);
        double nu0 = 4 * Math.PI * Math.Pow(10, -7);
        double N = 1500;

        double Ic = 0;

        // /Наборы переменных и массивов 
        public MainWindow()
        {
            InitializeComponent();
            //double step = 0.14285714285714285714285714285714; // Экспериментов = 7
            //DG.Columns.Insert(DG.Columns.Count, new DataGridTextColumn { Header = "Анодный ток (Ia)" });
            //DG.Columns.Insert(DG.Columns.Count, new DataGridTextColumn { Header = "Ток соленоида (Ic)" });
            //DG.Columns.Insert(DG.Columns.Count, new DataGridTextColumn { Header = "ΔIa" });
            //DG.Columns.Insert(DG.Columns.Count, new DataGridTextColumn { Header = "ΔIa/ΔIc" });
        }

        double ClickCountUa(int ccount)
        {
            if (ccount == 0)
            {
                return Ua[0];
            }
            else if (ccount == 1)
            {
                return Ua[1];
            }
            else if (ccount == 2)
            {
                return Ua[2];
            }
            else if (ccount == 3)
            {
                return Ua[3];
            }
            else if (ccount == 4)
            {
                return Ua[4];
            }
            else if (ccount == 5)
            {
                return Ua[5];
            }
            else if (ccount == 6)
            {
                return Ua[6];
            }
            else if (ccount == 7)
            {
                return Ua[7];
            }
            else
            {
                return 0;
            }
        }





        private void UaRead_Click(object sender, RoutedEventArgs e)
        {
            rotateTransform1.Angle = -57;
            // нужно отправить анодное напряжение

            string str = "Анодное напряжение установлено. Ua = " + ClickCountUa(UaClickCount).ToString();
            MessageBox.Show(str, "Успешно!", MessageBoxButton.OK, MessageBoxImage.Asterisk);
        }

     
       
        


        void M()
        {







            /* Вычисление Icкр для каждого Ua */
            for (int i = 0; i < Ua.Count; i++)
            {
                double k = Math.Sqrt((8*Ua[i])/em) * (l/(Ra*nu0*N));
                Ickr.Add(k);
            }








            //double Ia = (Imax - Imin) / ((Math.Pow(Math.E, (10*Ic)) + 1) + Imin)

            List<double> x = new List<double>();
            for (int i = -50; i < 50; i++)
            {
                x.Add(i);
            }

            for (int i = 0; i < x.Count; i++)
            {
            }
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show
        }


       

        //double ClickCountIc(int ccount)
        //{
        //    if (ccount == 0)
        //    {
        //        return Ia[0];
        //    }
        //    else if (ccount == 1)
        //    {
        //        return Ia[1];
        //    }
        //    else if (ccount == 2)
        //    {
        //        return Ia[2];
        //    }
        //    else if (ccount == 3)
        //    {
        //        return Ia[3];
        //    }
        //    else if (ccount == 4)
        //    {
        //        return Ia[4];
        //    }
        //    else if (ccount == 5)
        //    {
        //        return Ia[5];
        //    }
        //    else if (ccount == 6)
        //    {
        //        return Ia[6];
        //    }
        //    else if (ccount == 7)
        //    {
        //        return Ia[7];
        //    }
        //    else
        //    {
        //        return 0;
        //    }
        //}













        



        
        void ToRotateIc(Image img1)
        {
           

            l1++;
            m1++;
            p1++;
            b1++;
            y1++;
            x1++;
            z1++;
            var k = rotateTransform1.Angle;

            if (l1 == 10)
            {
                l1 = 0;
                rotateTransform1.Angle += 0.5;
            }
            if (m1 == 15)
            {
                m1 = 0;
                rotateTransform1.Angle += 0.5;
            }
            if (p1 == 18)
            {
                p1 = 0;
                rotateTransform1.Angle += 0.5;
            }
            if (b1 == 23)
            {
                b1 = 0;
                rotateTransform1.Angle += 0.5;
            }
            if (y1 == 27)
            {
                y1 = 0;
                rotateTransform1.Angle += 0.5;
            }
            if (x1 == 41)
            {
                x1 = 0;
                rotateTransform1.Angle -= 0.3;
            }

            if (z1 == 45)
            {
                z1 = 0;
                rotateTransform1.Angle -= 1;
            }
            rotateTransform1.Angle += 2.2;


            IcClickCount++;
            textb.Text = IcClickCount.ToString();
            if (IcClickCount == 51)
            {
                IcClickCount = 0;
                l1 = 0;
                m1 = 0;
                p1 = 0;
                b1 = 0;
                y1 = 0;
                x1 = 0;
                z1 = 0;

                rotateTransform1.Angle = -57;
            }

            img1.RenderTransform = rotateTransform1;
            //ClickCountIc(IcClickCount);

        }
        void ToRotateIa(Image img2)
        {
            l2++;
            m2++;
            p2++;
            b2++;
            y2++;
            x2++;
            z2++;
            var k = rotateTransform2.Angle;

            if (l2 == 10)
            {
                l2 = 0;
                rotateTransform2.Angle += 0.5;
            }
            if (m2 == 14)
            {
                m2 = 0;
                rotateTransform2.Angle += 0.7;
            }
            if (p2 == 16)
            {
                p2 = 0;
                rotateTransform2.Angle += 0.7;
            }
            if (b2 == 19)
            {
                b2 = 0;
                rotateTransform2.Angle += 0.5;
            }
            if (y2 == 26)
            {
                y2 = 0;
                rotateTransform2.Angle += 0.5;
            }
            if (x2 == 41)
            {
                x2 = 0;
                rotateTransform2.Angle -= 0.3;
            }

            if (z2 == 45)
            {
                z2 = 0;
                rotateTransform2.Angle -= 1;
            }
            rotateTransform2.Angle += 3.5;


            img2.RenderTransform = rotateTransform2;

            
        }
        public void ToRotateUa(Image img3)
        {
            l3++;
            m3++;
            p3++;
            b3++;
            y3++;
            x3++;
            z3++;
            var k = rotateTransform3.Angle;

            if (l3 == 4)
            {
                l3 = 0;
                rotateTransform3.Angle += 0.7;
            }
            if (m3 == 7)
            {
                m3 = 0;
                rotateTransform3.Angle += 0.5;

                rotateTransform3.Angle = 0;
            }
            
            rotateTransform3.Angle += 3.3;


            img3.RenderTransform = rotateTransform3;

            UaClickCount++;
            
            if (UaClickCount == 7)
            {
                UaClickCount = 0;
                l3 = 0;
                m3 = 0;
            }
            ClickCountUa(UaClickCount);
           
            
        }
        // /Процесс изменения положения (угла) стрелки каждого прибора




        /*Непосредственно, расчет и передача в MouseDown каждого прибора*/
        private void Ic_Arrow_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ToRotateIc(Ic_Arrow);
        }

        private void Ia_Arrow_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ToRotateIa(Ia_Arrow);
        }

        private void Ua_Arrow_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ToRotateUa(Ua_Arrow);
        }
        /*/Непосредственно, расчет и передача в MouseDown каждого прибора*/
    }


}