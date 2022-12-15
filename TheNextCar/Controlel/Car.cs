using System;
using System.Collections.Generic;
using System.Text;
using TheNextCar.Controlel;

namespace TheNextCar.Controller
{
    class Car
    {
        private DoorController doorController;
        private AccubaterryController accubaterryController;
        private oncarEngineStateChanged callback;
        private MainWindow mainWindow;

        public Car(DoorController doorController, AccubaterryController accubaterryController, oncarEngineStateChanged callback)
        {
            this.doorController = doorController;
            this.accubaterryController = accubaterryController;
            this.callback = callback;
        }

        public Car(AccubaterryController accubaterryController, DoorController doorController, MainWindow mainWindow)
        {
            this.accubaterryController = accubaterryController;
            this.doorController = doorController;
            this.mainWindow = mainWindow;
        }

        private bool doorIsClosed()
        {
            return this.doorController.isClose();
        }

        private bool doorIsLocked()
        {
            return this.doorController.isLocked();
        }

        private bool powerIsReady()
        {
            return this.accubaterryController.accubatteryIsOn();
        }

        public void startEngine()
        {
            if (!doorIsClosed())
            {
                this.callback.onCarEngineStateChanged("STOPED", "Close the door");
                return;
            }
            if (!doorIsLocked())
            {
                this.callback.onCarEngineStateChanged("STOPED", "Lock the door");
                return;
            }

            if (!powerIsReady())
            {
                this.callback.onCarEngineStateChanged("STOPED", "no power available");
                return;
            }
            this.callback.onCarEngineStateChanged("STARTED", "Engine Started");
        }

        public void toogleTheLockDoorButton()
        {

            if (!doorIsLocked())
            {
                this.doorController.activateLock();
            }
            else
            {
                this.doorController.unlock();
            }
        }

        public void toogleTheOpenDoorButton()
        {
            if (!doorIsClosed())
            {
                this.doorController.close();
            }
            else
            {
                this.doorController.open();
            }
        }
        public void tooglePowerButton()
        {
            if (!powerIsReady())
            {
                this.accubaterryController.turnOn();
            }
            else
            {
                this.accubaterryController.turnOff();
            }
        }
    }
    interface oncarEngineStateChanged
    {
        void onCarEngineStateChanged(string value, string message);
    }
}
