## The Next Car

Aplikasi The Next Car ini berfungsi sebagai Keamanan saat mengendarai mobil.

### Scope of Functionalities

* Kegunaan DoorControler.cs
* Kegunaan model Door.cs
* Kegunaan Interface OnDoorChanged

##### 1. Kegunaan DoorControler.cs
    DoorController.cs berfungsi untuk mengetahui fungsi door closed atau Locked.

``` javascript

    namespace TheNextCar.Controller
{
    class DoorController
    {
        private Door door;
        private OnDooorChanged callbackOnDoorChanged;

        public DoorController(OnDooorChanged callbackOnDoorChanged)
        {
            this.callbackOnDoorChanged = callbackOnDoorChanged;
            this.door = new Door();
        }
        public void close()
        {
            this.door.close();
            this.callbackOnDoorChanged.onDoorOpenStateChanged("CLOSED", "door closed");
        }
        public void open()
        {
            this.door.open();
            this.callbackOnDoorChanged.onDoorOpenStateChanged("OPENED", "door opened");
        }
        public void activateLock()
        {
            this.door.activateLock();
            this.callbackOnDoorChanged.onLockDoorStateChanged("LOCKED", "door locked");
        }

        public void unlock()
        {
            this.door.unlock();
            this.callbackOnDoorChanged.onLockDoorStateChanged("UNLOCKED", "door unlocked");
        }

        public bool isClose()
        {
            return this.door.isClosed();
        }
        public bool isLocked()
        {
            return this.door.isLocked();
        }
    }
``` 

##### 2. Kegunaan Model Door.cs
    Door.cs berfungsi untuk mengetahui door Closed atau Locked

``` csharp
    
namespace TheNextCar.Model
{
    class Door
    {
        private bool closed;
        private bool locked;

        public void close()
        {
            this.closed = true;
        }

        public void open()
        {
            this.closed = false;
        }

        public void activateLock()
        {
            this.locked = true;
        }

        public void unlock()
        {
            this.locked = false;
        }

        public bool isLocked()
        {
            return this.locked;
        }

        public bool isClosed()
        {
            return this.closed;
        }
    }
}
```

##### 3. •Kegunaan Interface OnDoorChanged
   Interface OnDoorChanged berfungsi untuk mengganti fungsi dari Door dan DoorController

``` javascript

    interface OnDooorChanged
    {
        void onLockDoorStateChanged(string value, string message);
        void onDoorOpenStateChanged(string value, string message);
    }
```

## Nama : Yonas Danga P
## NIM  : 19.11.2823