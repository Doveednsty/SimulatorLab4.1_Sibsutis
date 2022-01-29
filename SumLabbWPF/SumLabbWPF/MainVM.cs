using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                MessageBox.Show($"Имя: {SelectedItem.IaDG}\nФамилия: {SelectedItem.IcDG}\nВозраст: {SelectedItem.DeltaIa}");
        }
    }
}
