using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT2COM
{
    public static class CExtentions
    {
        public static string ToHexBleAddress(this Guid id)
        {
            return id.ToString("N")[20..].ToUpperInvariant();
        }
    }
}
