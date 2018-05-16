using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace ExtensionActiveX
{
    [Guid("C3C1E99A-8CB2-4602-B03E-71D0881AC87A")]
    [ComVisible(true)]
    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface IEventos
    {
        [DispId(0x00000001)]
        void Evento(string nombre);
    }
}
