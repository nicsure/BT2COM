using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT2COM
{
    public static class Com
    {
        private static SerialPort? com = null;

        public static bool Open(string portName)
        {
            SerialPort? port = null;
            try
            {
                port = new SerialPort(portName);
                port.Open();
                com = port;
                return true;
            }
            catch { }
            Close(port);
            return false;
        }

        public static void Close()
        {
            Close(com);
            com = null;
        }

        public static void Close(SerialPort? port)
        {
            try { port?.Close(); } catch { }
            using (port) { }
        }

        public static void ReadLoop()
        {
            byte[] buffer = new byte[1024];
            while (true)
            {
                int br;
                try { br = com?.Read(buffer, 0, 1024) ?? -1; } catch { br = -1; }
                if (br > 0)
                {
                    byte[] b = new byte[br];
                    Array.Copy(buffer, 0, b, 0, br);
                    using var wTask = BT.Write(b);
                    wTask.Wait();
                }
                else
                    Thread.Sleep(500);
            }
        }

        public static void Write(byte[] b)
        {
            try { com?.Write(b, 0, b.Length); } catch { }
        }
    }
}
