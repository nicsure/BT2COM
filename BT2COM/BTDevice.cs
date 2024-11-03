using Plugin.BLE.Abstractions.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT2COM
{
    public class BTDevice(IDevice device) : IDisposable
    {
        public IDevice Device { get; private set; } = device;

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            using(Device) { }
        }

        public override string ToString()
        {
            return $"{Device.Name} {Device.Id.ToHexBleAddress()[^5..]}";
        }
    }
}
