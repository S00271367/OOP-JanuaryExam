using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace OOP_JanuaryExam
{
    public class Robot : INotifyPropertyChanged
    {
        private string _robotName;
        private double _powerCapacityKWH;
        private double _currentPowerKWH;

        public string RobotName
        {
            get => _robotName;
            set
            {
                if (_robotName == value) return;
                _robotName = value;
                OnPropertyChanged(nameof(RobotName));
                OnPropertyChanged(nameof(Description));
                OnPropertyChanged(nameof(BatteryInfo));
            }
        }

        public double PowerCapacityKWH
        {
            get => _powerCapacityKWH;
            set
            {
                if (Math.Abs(_powerCapacityKWH - value) < double.Epsilon) return;
                _powerCapacityKWH = value;
                OnPropertyChanged(nameof(PowerCapacityKWH));
                OnPropertyChanged(nameof(BatteryPercentage));
                OnPropertyChanged(nameof(BatteryInfo));
            }
        }

        public double CurrentPowerKWH
        {
            get => _currentPowerKWH;
            set
            {
                if (Math.Abs(_currentPowerKWH - value) < double.Epsilon) return;
                _currentPowerKWH = value;
                OnPropertyChanged(nameof(CurrentPowerKWH));
                OnPropertyChanged(nameof(BatteryPercentage));
                OnPropertyChanged(nameof(BatteryInfo));
            }
        }

        public Robot() { }

        public Robot(string name, double powerCapacityKWH, double currentPowerKWH)
        {
            _robotName = name;
            _powerCapacityKWH = powerCapacityKWH;
            _currentPowerKWH = currentPowerKWH;
        }

        public double BatteryPercentage
        {
            get
            {
                if (PowerCapacityKWH <= 0) return 0;
                return (CurrentPowerKWH / PowerCapacityKWH) * 100;
            }
        }

        public string BatteryInfo => $"Robot {RobotName} has {BatteryPercentage:F2}% battery remaining.";

        public string Description => $"Robot Name: {RobotName}, Power Capacity: {PowerCapacityKWH} KWH, Current Power: {CurrentPowerKWH} KWH";

        public double GetBatteryPercentage()
        {
            return BatteryPercentage;
        }

        public string DisplayBatteryInformation()
        {
            return BatteryInfo;
        }

        public string DescribeRobot()
        {
            return Description;
        }

        public override string ToString()
        {
            return Description;
        }

        //create 6 robots
        public static List<Robot> CreateSixSampleRobots()
        {
            var robots = new List<Robot>();

            // Household robots
            robots.Add(new HouseholdRobot(
                "HouseBot",
                12.0,
                9.0,
                new[] { HouseholdSkill.Cleaning, HouseholdSkill.Laundry }
            ));

            robots.Add(new HouseholdRobot(
                "GardenMate",
                15.0,
                11.5,
                new[] { HouseholdSkill.Gardening, HouseholdSkill.Cleaning }
            ));

            robots.Add(new HouseholdRobot(
                "Housemate 3000",
                20.0,
                18.0,
                new[] { HouseholdSkill.Cooking, HouseholdSkill.ChildCare }
            ));

            // Delivery robots
            robots.Add(new DeliveryRobot(
                "DeliverBot",
                18.0,
                14.0,
                DeliveryMode.Walking,
                8.0
            ));

            robots.Add(new DeliveryRobot(
                "FlyBot",
                25.0,
                20.0,
                DeliveryMode.Flying,
                3.5
            ));

            robots.Add(new DeliveryRobot(
                "Driver",
                22.0,
                16.0,
                DeliveryMode.Driving,
                20.0
            ));

            return robots;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
