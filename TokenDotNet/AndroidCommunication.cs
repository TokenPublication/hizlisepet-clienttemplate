using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TokenDotNet
{
    internal class AndroidCommunication
    {
        private static AndroidCommunication _instance;
        //Import C++ functions from the Hizli Sepet Dll

        //Create an heap allocated C++ androidCommunication object
        [DllImport("HizliSepetSerial.dll")]
        private static extern IntPtr c_createAndroidCommunication();

        //Delete the heap allocated C++ androidCommunication object to free resources
        [DllImport("HizliSepetSerial.dll")]
        private static extern void c_deleteAndroidCommunication(IntPtr androidCommunicationPtr);

        [DllImport("HizliSepetSerial.dll")]
        private static extern int c_sendBasket(IntPtr androidCommunicationPtr, string jsonData);

        [DllImport("HizliSepetSerial.dll")]
        [return: MarshalAs(UnmanagedType.BStr)]
        private static extern string c_getFiscalInfo(IntPtr androidCommunicationPtr);

        [DllImport("HizliSepetSerial.dll")]
        [return: MarshalAs(UnmanagedType.BStr)]
        private static extern string c_getDeviceInfo(IntPtr androidCommunicationPtr);

        [DllImport("HizliSepetSerial.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void c_setSerialInCallback(IntPtr androidCommunicationPtr, SerialInCallback callback);

        [DllImport("HizliSepetSerial.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void c_setDeviceStateCallback(IntPtr androidCommunicationPtr, DeviceStateCallback callback);

        //Pointer to the C++ androidCommunication object.
        private readonly IntPtr _androidCommunication;

        public delegate int SerialInCallback(int type, string value);
        public delegate void DeviceStateCallback(bool isDeviceConnected, string id);

        private SerialInCallback _serialInCallback;
        private DeviceStateCallback _deviceStateCallback;

        public AndroidCommunication()
        {
            _androidCommunication = c_createAndroidCommunication();
        }

        ~AndroidCommunication()
        {
            c_deleteAndroidCommunication(_androidCommunication);
        }

        public int sendBasket(string jsonData)
        {
            return c_sendBasket(_androidCommunication, jsonData);
        }

        public string getFiscalInfo()
        {
            return c_getFiscalInfo(_androidCommunication);
        }

        public string getDeviceInfo()
        {
            return c_getDeviceInfo(_androidCommunication);
        }

        public void setSerialInCallback(SerialInCallback callback)
        {
            _serialInCallback = callback;
            c_setSerialInCallback(_androidCommunication, _serialInCallback);
        }

        public void setDeviceStateCallback(DeviceStateCallback callback)
        {
            _deviceStateCallback = callback;
            c_setDeviceStateCallback(_androidCommunication, _deviceStateCallback);
        }
        public static AndroidCommunication Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new AndroidCommunication();
                }
                return _instance;
            }
        }
    }
}
