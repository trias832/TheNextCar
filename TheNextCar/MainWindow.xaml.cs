﻿using System;
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
using TheNextCar.Controller;
namespace TheNextCar
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, OnPowerChanged, onDoorChanged, onCarEngineStatusChanged
    {
        private Car nextCar;
        public MainWindow()
        {
            InitializeComponent();
            AccubatteryController accubatteryController = new AccubatteryController(this);
            DoorController doorController = new DoorController(this);
            nextCar = new Car(accubatteryController, doorController, this);
        }

       
        private void OnDoorOpenButtonClicked(object sender, RoutedEventArgs e)
        {
            this.nextCar.toggleTheDoorButton();
        }

      

        private void OnLockDoorButtonClicked(object sender, RoutedEventArgs e)
        {
            this.nextCar.toggleTheLoockDoorButton();
        }

        private void OnStartButtonClicked(object sender, RoutedEventArgs e)
        {
            this.nextCar.toggleStartEngineButton();

        }

        private void OnAccuButtonClicked(object sender, RoutedEventArgs e)
        {
            this.nextCar.toggleThePowerButton();
        }

        public void onPowerChangedStatus(string value, string message)
        {
            this.AccuState.Content = message;
            this.AccuButton.Content = value;
        }
        public void doorSecurityChanged(string value,string message)
        {
            this.LockDoorState.Content = message;
            this.LockDoorButton.Content = value;
        }
        public void doorStatusChanged(string value,string message)
        {
            this.DoorOpenState.Content = message;
            this.DoorOpenButton.Content = value;
        }
        public void carEngineStatusChanged(string value,string message)
        {
            status.Content = message;
            StartButton.Content = value;
        }
    }
}
