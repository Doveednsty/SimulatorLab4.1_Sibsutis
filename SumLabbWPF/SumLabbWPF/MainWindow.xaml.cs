using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;


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

        List<double> Ua = new List<double>() { 16, 17, 18, 19, 20, 21, 22 }; // В
        List<double> Imax = new List<double>() { 1, 1.166, 1.333, 1.499, 1.666, 1.833, 2 }; // мА
        List<double> Imin = new List<double>() { 0.3, 0.366, 0.433, 0.5, 0.566, 0.633, 0.7}; // мА
        List<double> Ickr = new List<double>() { 0.286, 0.295, 0.304, 0.312, 0.32, 0.328, 0.336}; // мА
        double Ia = 0;

        double em = 1.76 * 1000; //Math.Pow(10, 4);
        double l = 0.1;
        double Ra = 5 * 0.001; //Math.Pow(10, -3);
        double nu0 = 4 * 3.14 * 0.0000001;//Math.Pow(10, -7);
        double N = 1500;

        double Ic = 0;

        // /Наборы переменных и массивов 
















        private MainVM MainVM { get; } = new MainVM();
        public MainWindow()
        {
            InitializeComponent();
            //double step = 0.14285714285714285714285714285714; // Экспериментов = 7
            DataContext = MainVM;
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
            IcClickCount = 0;

            var a = ClickCountUa(UaClickCount);
            
            
            string str = "Анодное напряжение установлено. Ua = " + ClickCountUa(UaClickCount).ToString() + "\nУстанавливайте и снимайте показания тока соленоида и анодного тока";
            MessageBox.Show(str, "Успешно!", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            
        }

       

       
        public double IcCurrent(int IcCurrentCC)
        {
            int ic = 0;
            for (int i = 0; i < 51; i++)
            {
                
                if (i == IcCurrentCC)
                {
                    return ic;
                    break;
                }
                else
                {
                    ic += 20;
                }
            }
            return 0;
        }

        public void M(double a)
        {
            var aa = a;
            var b = IcCurrent(IcClickCount);

            IaCalc(aa / 1000, b / 1000);
        }


        public double IaCalc(double UaCurrent, double IcCurrent)
        {


            for (int i = 0; i < Ua.Count; i++)
            {
                if (UaCurrent == Ua[i] / 1000)
                {
                    Ia = ((Imax[i] - Imin[i]) / (Math.Pow(Math.E, (10 * IcCurrent - (10 * Ickr[i]))) + 1)) + Imin[i];
                    
                }
            }

            textb.Text = (UaCurrent * 1000).ToString() + " " + (IcCurrent * 1000).ToString() + "     =     " + Ia.ToString();

            return 0;
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show
        }
        
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
                rotateTransform1.Angle += 0.35;
            }
            if (x1 == 41)
            {
                x1 = 0;
                rotateTransform1.Angle -= 0.4;
            }

            if (z1 == 45)
            {
                z1 = 0;
                rotateTransform1.Angle -= 1.5;
            }
            rotateTransform1.Angle += 2.2;


            IcClickCount++;
            //textb.Text = IcClickCount.ToString();
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
            
            rotateTransform3.Angle += 3.5;


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

        void R(Image img2)
        {
            var k = rotateTransform2.Angle;
            rotateTransform2.Angle += 3.65;


            img2.RenderTransform = rotateTransform2;
        }


        /*Непосредственно, расчет и передача в MouseDown каждого прибора*/
        private void Ic_Arrow_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ToRotateIc(Ic_Arrow);
            var a = ClickCountUa(UaClickCount);
            M(a);
        }

        private void Ia_Arrow_MouseDown(object sender, MouseButtonEventArgs e)
        {
            R(Ia_Arrow);
        }

        private void Ua_Arrow_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ToRotateUa(Ua_Arrow);
        }
        /*/Непосредственно, расчет и передача в MouseDown каждого прибора*/
    }


}