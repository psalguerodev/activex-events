using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace ExtensionActiveX
{
    [ComImport(),
     Guid("CB5BDC81-93C1-11CF-8F20-00805F2CD064"),
     InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ISeguridad
    {
        [PreserveSig]
        long GetInterfaceSafetyOptions(ref Guid iid, out int pdwSupportedOptions, out int pdwEnabledOptions);

        [PreserveSig]
        long SetInterfaceSafetyOptions(ref Guid iid, int dwOptionSetMask, int dwEnabledOptions);
    }
}
