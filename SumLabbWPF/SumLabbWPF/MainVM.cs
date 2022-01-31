using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace SumLabbWPF
{
    public class MainVM
    {
        public ObservableCollection<LabDataVM> LabData { get; set; } = new ObservableCollection<LabDataVM>();
        public LabDataVM SelectedItem { get; set; }

        public ICommand AddRowCommand { get; set; }
        public ICommand GetRowInfoCommand { get; set; }

        public MainVM()
        {
            AddRowCommand = new RelayCommand(AddRow);
            GetRowInfoCommand = new RelayCommand(GetRowInfo);
        }

        private void AddRow() => LabData.Add(new LabDataVM("0", "0", "0", "0"));

        private void GetRowInfo()
        {
            if (SelectedItem != null)
                MessageBox.Show($"Анодный ток = {SelectedItem.IaDG}\nТок соленоида =  {SelectedItem.IcDG}\nΔIa = {SelectedItem.DeltaIa}\nОтношение Ia/Ic = {SelectedItem.DeltaIa}");
        }
    }
}
