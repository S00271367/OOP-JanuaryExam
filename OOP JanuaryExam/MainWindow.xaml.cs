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
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace OOP_JanuaryExam
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        // Expose collection and selected item for binding
        public ObservableCollection<Robot> Robots { get; } = new ObservableCollection<Robot>();

        private List<Robot> _allRobots = new List<Robot>();

        private Robot _selectedRobot;
        public Robot SelectedRobot
        {
            get => _selectedRobot;
            set
            {
                if (_selectedRobot == value) return;
                _selectedRobot = value;
                OnPropertyChanged(nameof(SelectedRobot));
            }
        }

        public MainWindow()
        {
            InitializeComponent();

            // set DataContext so bindings in XAML work against this class
            DataContext = this;

            // Load all sample robots once and keep a master list for filtering
            _allRobots = Robot.CreateSixSampleRobots();

            // Populate ObservableCollection with all items initially
            ShowAllRobots();

            // default filter = All
            AllRadio.IsChecked = true;

            // optionally select the first robot
            if (Robots.Count > 0) SelectedRobot = Robots[0];
        }

        // RadioButton Checked handler — updates the Robots collection based on selection
        private void FilterRadio_Checked(object sender, RoutedEventArgs e)
        {
            if (AllRadio.IsChecked == true)
            {
                ShowAllRobots();
            }
            else if (HouseholdRadio.IsChecked == true)
            {
                ShowHouseholdRobots();
            }
            else if (DeliveryRadio.IsChecked == true)
            {
                ShowDeliveryRobots();
            }

            // keep selection valid after filtering
            if (!Robots.Contains(SelectedRobot))
                SelectedRobot = Robots.FirstOrDefault();
        }

        private void ShowAllRobots()
        {
            Robots.Clear();
            foreach (var r in _allRobots)
                Robots.Add(r);
        }

        private void ShowHouseholdRobots()
        {
            Robots.Clear();
            foreach (var r in _allRobots.OfType<HouseholdRobot>())
                Robots.Add(r);
        }

        private void ShowDeliveryRobots()
        {
            Robots.Clear();
            foreach (var r in _allRobots.OfType<DeliveryRobot>())
                Robots.Add(r);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
