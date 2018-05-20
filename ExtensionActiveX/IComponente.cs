using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace ExtensionActiveX
{
    [Guid("F79C4C4F-02B8-4046-99F6-79CD27A9B3A7"),
    InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface IComponente
    {
        [DispId(1)]
        void SaludarPorNombre(string nombre);

        [DispId(2)]
        int GenerarAleatorio(string nombre);

        [DispId(3)]
        void ProcesoAsinc(string data);
    }
}
