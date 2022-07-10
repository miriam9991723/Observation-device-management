using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using BO;
using BlApi;
using System.Globalization;

namespace PL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IBL bl;
        public MainWindow()
        {
            InitializeComponent();
            bl = BLFactory.GetBL();
            comboBoxTypeFilter.ItemsSource = Enum.GetValues(typeof(DeviceType));
            comboBoxTypeAddDevice.ItemsSource = Enum.GetValues(typeof(DeviceType));
            comboBoxTypeAddDevice.SelectedItem = DeviceType.Radar;
            updateListView();
        }
        public ObservableCollection<T> Convert<T>(IEnumerable<T> original)
        {
            return new ObservableCollection<T>(original);
        }

        private void ShowAllDevices_Click(object sender, RoutedEventArgs e)
        {
            updateListView();
        }

        private void SortByType_Click(object sender, RoutedEventArgs e)
        {
            DataContext = Convert(bl.GetDevicesSortedByRange());
        }

        private void HighestRange_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                float minimun = getTextBoxAsFloat(minimumTextBox, "minimum");
                DataContext = Convert(bl.GetHighestRangeWithMinimalfieldOfVision(minimun));
            }
            catch (InvalidInputException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AddDevice_Click(object sender, RoutedEventArgs e)
        {
            int range = 0;
            float fielsOfVision = 0;
            DeviceType deviceType = DeviceType.Binoculars;
            try
            {
                deviceType = getComboBoxAsDeviceType(comboBoxTypeAddDevice);
                range = getTextBoxAsInt(rangeTextBox, "range");
                fielsOfVision = getTextBoxAsFloat(fieldOfVisionTextBox, "field of vision");

            }
            catch (InvalidInputException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            try
            {
                int id = bl.AddDevice(deviceType, range, fielsOfVision);
                MessageBox.Show("device added successfuly! Id: " + id + ".");
                updateListView();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } 
        }

        private void typeFilterchanged(object sender, RoutedEventArgs e)
        {
            try
            {
                var selected = getComboBoxAsDeviceType(comboBoxTypeFilter);
                DataContext = Convert(bl.GetDevicesOfSpecificType(selected));
            }
            catch (InvalidInputException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void remove_Click(object sender, RoutedEventArgs e)
        {
            int id = -1;
            try
            {
                id = getTextBoxAsInt(IdTextBox, "id");
                bl.RemoveDevice(id);
                MessageBox.Show("device " + id + " removed successfuly!");
                updateListView();
            }
            catch (InvalidInputException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (KeyNotFoundException)
            {
                MessageBox.Show("Device with id: "+id.ToString()+" not found");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void updateListView()
        {
            DataContext = Convert(bl.GetAllDevices());
        }

        private int getTextBoxAsInt(TextBox textBox, string nameOfField)
        {
            try
            {
                return Int32.Parse(textBox.Text);

            }
            catch (FormatException)
            {
                throw new InvalidInputException(nameOfField);
            }
            catch (OverflowException)
            {
                throw new InvalidInputException(nameOfField);
            }
        }

        private float getTextBoxAsFloat(TextBox textBox, string nameOfField)
        {
            try
            {
                var culture = (CultureInfo)CultureInfo.CurrentCulture.Clone();
                culture.NumberFormat.NumberDecimalSeparator = ".";
                return float.Parse(textBox.Text, culture);
            }
            catch (FormatException)
            {
                throw new InvalidInputException(nameOfField);
            }
        }

        private DeviceType getComboBoxAsDeviceType(ComboBox comboBox)
        {
            try
            {
                return (DeviceType)comboBox.SelectedItem;

            }
            catch (FormatException)
            {
                throw new InvalidInputException("device type");
            }
        }
    }
}
