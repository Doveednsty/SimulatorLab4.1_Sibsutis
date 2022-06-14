using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace SumLabbWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<double> Ua = new List<double>() { 16, 17, 18, 19, 20, 21, 22 }; // В
        List<double> Imax = new List<double>() { 1, 1.166, 1.333, 1.499, 1.666, 1.833, 2 }; // мА
        List<double> Imin = new List<double>() { 0.3, 0.366, 0.433, 0.5, 0.566, 0.633, 0.7}; // мА
        List<double> Ickr = new List<double>() { 0.286, 0.295, 0.304, 0.312, 0.32, 0.328, 0.336}; // мА
        double Ia = 0;

        //double em = 1.76 * 1000; //Math.Pow(10, 4);
        //double l = 0.1;
        //double Ra = 5 * 0.001; //Math.Pow(10, -3);
        //double nu0 = 4 * 3.14 * 0.0000001;//Math.Pow(10, -7);
        //double N = 1500;

        //double Ic = 0;

        double UaInTextBox = 0;
        // /Наборы переменных и массивов 
















        private MainVM MainVM { get; } = new MainVM();
        public MainWindow()
        {
            InitializeComponent();
            //double step = 0.14285714285714285714285714285714; // Экспериментов = 7
            DataContext = MainVM;
        }




       

        private void UaRead_Click(object sender, RoutedEventArgs e)
        {   
            try
            {
                
                UaInTextBox = Convert.ToDouble(Ua_TextBox.Text);
                string str = "Анодное напряжение установлено. Ua = " + Ua_TextBox.Text + "\nУстанавливайте и снимайте показания тока соленоида и анодного тока";
                MessageBox.Show(str, "Успешно!", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
            catch (Exception)
            {
                MessageBox.Show("Произошла ошибка. Проверьте правильность набранных данных (Например, точка вместо запятой в записи десятичных чисел)", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }


        private void CalcBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                M(Convert.ToDouble(Ic_TextBox.Text));
            }
            catch (Exception)
            {
                MessageBox.Show("Произошла ошибка. Проверьте правильность набранных данных (Например, точка вместо запятой в записи десятичных чисел)", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
         
        

        public void M(double Ic)
       {
            IaCalc(UaInTextBox, Ic/1000);
        }


        public double IaCalc(double UaCurrent, double IcCurrent)
        {


            for (int i = 0; i < Ua.Count; i++)
            {
                if (UaCurrent == Ua[i])
                {
                    Ia = ((Imax[i] - Imin[i]) / (Math.Pow(Math.E, (10 * IcCurrent - (10 * Ickr[i]))) + 1)) + Imin[i];
                    
                }
                
            }
            //Ia_TextBox.Text = (UaCurrent * 1000).ToString() + " " + (IcCurrent * 1000).ToString() + "     =     " + Ia.ToString();
            //tb.Text = UaCurrent.ToString() + "  " + IcCurrent.ToString() + " = " + Ia.ToString();

            Ia_TextBox.Text = Math.Round(Ia, 2).ToString();
            return 0;
        }
        

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }







        private void Ua_TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!(Char.IsDigit(e.Text, 0) || (e.Text == ",")
               && (!Ua_TextBox.Text.Contains(",")
               && Ua_TextBox.Text.Length != 0)))
            {
                e.Handled = true;
            }
        }

        private void Ia_TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!(Char.IsDigit(e.Text, 0) || (e.Text == ",")
               && (!Ia_TextBox.Text.Contains(",")
               && Ua_TextBox.Text.Length != 0)))
            {
                e.Handled = true;
            }
        }


        private void Ic_TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!(Char.IsDigit(e.Text, 0) || (e.Text == ",")
               && (!Ic_TextBox.Text.Contains(",")
               && Ua_TextBox.Text.Length != 0)))
            {
                e.Handled = true;
            }
        }


        private void HelpBtn_Click(object sender, RoutedEventArgs e)
        {
            HelpWindow helpWindow = new HelpWindow();
            helpWindow.ShowDialog();
        }

        private void OTS_Click(object sender, RoutedEventArgs e)
        {
            OTSWindow oTSWindow = new OTSWindow();
            oTSWindow.ShowDialog();
        }
    }


}