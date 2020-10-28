using System;
using System.Collections.Generic;
using System.Text;

namespace TheNextCar.Controller
{
    class Car
    {
        AccubatteryController accubatteryController;
        DoorController doorController;
        onCarEngineStatusChanged callbackCarEngineStatusChanged;

        public Car(AccubatteryController accubatteryController, DoorController doorController, onCarEngineStatusChanged callbackCarEngineStatusChanged)
        {
            this.accubatteryController = accubatteryController;
            this.doorController = doorController;
            this.callbackCarEngineStatusChanged = callbackCarEngineStatusChanged;
        }

        public void turnOnPower()
        {
            this.accubatteryController.turnOn();
        }

        public void turnOfPower()
        {
            this.accubatteryController.turnOff();
        }

        public bool powerIsReady()
        {
            return this.accubatteryController.accubatteryIsOn();
        }

        public void closeTheDoor()
        {
            this.doorController.close();
        }

        public void openTheDoor()
        {
            this.doorController.open();
        }

        public void lockTheDoor()
        {
            this.doorController.activateLock();
        }

        public void unlockTheDoor()
        {
            this.doorController.unlock();
        }

        public bool doorIsClosed()
        {
            return this.doorController.isClose();
        }

        public bool doorIsLocked()
        {
            return this.doorController.isLocked();
        }

        public void toggleStartEngineButton()
        {
            if (!doorIsClosed())
            {
                this.callbackCarEngineStatusChanged.carEngineStatusChanged("STOPPED", "door is open");
                return;
            }
            if (!doorIsLocked())
            {
                this.callbackCarEngineStatusChanged.carEngineStatusChanged("STOPPED", "door unlocked");
                return;
            }
            if (!powerIsReady())
            {
                this.callbackCarEngineStatusChanged.carEngineStatusChanged("STOPPED", "no power available");
                return;
            }
            this.callbackCarEngineStatusChanged.carEngineStatusChanged("STARTED", "Engine Started");
        }

        public void toggleTheLoockDoorButton()
        {
            if (!doorIsLocked())
            {
                this.lockTheDoor();
            }
            else
            {
                this.unlockTheDoor();
            }
        }

        public void toggleTheDoorButton()
        {
            if (!doorIsClosed())
            {
                this.closeTheDoor();
            }
            else
            {
                this.openTheDoor();
            }
        }

        public void toggleThePowerButton()
        {
            if (!powerIsReady())
            {
                this.turnOnPower();
            }
            else
            {
                this.turnOfPower();
            }
        }
    }
    interface onCarEngineStatusChanged
    {
        void carEngineStatusChanged(string value, string message);
    }
}
