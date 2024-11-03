using Plugin.BLE.Abstractions.Contracts;
using Plugin.BLE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.BLE.Abstractions.Extensions;

namespace BT2COM
{
    public static class BT
    {
        private readonly static IAdapter adapter = CrossBluetoothLE.Current.Adapter;
        private static ICharacteristic? reader = null, writer = null;
        public static BTDevice? ConnectedDevice { get; private set; } = null;
        public static ComboBox DeviceCB { get; set; } = null!;
        private static CancellationTokenSource? connectCanceller = null;

        static BT()
        {            
            adapter.DeviceDiscovered += Adapter_DeviceDiscovered;
        }

        public static void Init(ComboBox cb) => DeviceCB = cb;

        private static void Adapter_DeviceDiscovered(object? sender, Plugin.BLE.Abstractions.EventArgs.DeviceEventArgs e)
        {
            DeviceCB.Invoke(() => 
            {
                DeviceCB.Items.Add(new BTDevice(e.Device));
            });
        }

        public static async Task Scan()
        {
            await Disconnect();
            foreach(var item in DeviceCB.Items)
            {
                if(item is BTDevice device)
                {
                    using (device) { }
                }
                DeviceCB.Items.Clear();
            }
            await adapter.StartScanningForDevicesAsync();
        }

        public static async Task Disconnect()
        {
            try
            {
                if (reader != null)
                {
                    reader.ValueUpdated -= Reader_ValueUpdated;
                    await reader.StopUpdatesAsync();
                }
            }
            catch { }
            try
            {
                if (ConnectedDevice != null)
                    await adapter.DisconnectDeviceAsync(ConnectedDevice.Device);
            }
            catch { }
            ConnectedDevice = null;
        }

        public static void CancelConnect()
        {
            try
            {
                (_ = connectCanceller)?.Cancel();
            }
            catch { }
        }

        public static async Task Connect()
        {
            await Disconnect();
            try
            {
                if (DeviceCB.SelectedItem is BTDevice device)
                {
                    using (connectCanceller = new())
                    {
                        await adapter.ConnectToDeviceAsync(device.Device, cancellationToken: connectCanceller.Token);
                    }
                    var services = await device.Device.GetServicesAsync();
                    foreach (var service in services)
                    {
                        if (service.Id.PartialFromUuid().ToLower().Equals("0xff00"))
                        {
                            var characteristics = await service.GetCharacteristicsAsync();
                            foreach (var characteristic in characteristics)
                            {
                                if (characteristic.CanUpdate)
                                    reader = characteristic;
                                if (characteristic.CanWrite)
                                    writer = characteristic;
                                if (reader != null && writer != null)
                                {
                                    reader.ValueUpdated -= Reader_ValueUpdated;
                                    reader.ValueUpdated += Reader_ValueUpdated;
                                    await reader.StartUpdatesAsync();
                                    ConnectedDevice = device;
                                    return;
                                }
                            }
                        }
                    }
                }
                else
                    return;
            }
            catch { }
            await Disconnect();
        }

        private static void Reader_ValueUpdated(object? sender, Plugin.BLE.Abstractions.EventArgs.CharacteristicUpdatedEventArgs e)
        {
            byte[] b = new byte[e.Characteristic.Value.Length];
            Array.Copy(e.Characteristic.Value, 0, b, 0, e.Characteristic.Value.Length);
            Com.Write(b);
        }

        public static async Task Write(byte[] b)
        {
            if (writer != null)
            {
                try
                {
                    await writer.WriteAsync(b);
                }
                catch { }
            }
        }

    }
}
