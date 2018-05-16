using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
namespace ExtensionActiveX
{
    [ProgId("ExtensionActiveX.Componente")]
    [ClassInterface(ClassInterfaceType.None)]
    [Guid("DD452733-2BD7-4BA7-883C-A756AC338A3E")]
    [ComDefaultInterface(typeof(IComponente))]
    [ComVisible(true)]
    public class Componente : ISeguridad , IComponente
    {
        #region [Implementacion de Modo Seguro Active X IExplorer]
        private ESeguridadOpciones m_options =
            ESeguridadOpciones.INTERFACESAFE_FOR_UNTRUSTED_CALLER |
            ESeguridadOpciones.INTERFACESAFE_FOR_UNTRUSTED_DATA;

        public long GetInterfaceSafetyOptions(ref Guid iid, out int pdwSupportedOptions, out int pdwEnabledOptions)
        {
            pdwSupportedOptions = (int)m_options;
            pdwEnabledOptions = (int)m_options;
            return 0;
        }
        public long SetInterfaceSafetyOptions(ref Guid iid, int dwOptionSetMask, int dwEnabledOptions)
        {
            return 0;
        }
        #endregion 
    
        #region [Implementacion de Metodos de IComponente]
        
        [ComVisible(false)]
        public delegate void ManejadorEvento(string args);
        public event ManejadorEvento Evento;

        public void SaludarPorNombre(string nombre)
        {
            MessageBox.Show(String.Format("Bienvenido al Componente Activex {0} sigue avanzando!!", nombre.ToUpper()), "Mensaje desde Active X", MessageBoxButtons.OK);
        }

        public int GenerarAleatorio(string nombre)
        {
            if (Evento != null)
                Evento(nombre);
            return (int)DateTime.Now.Ticks;
        }
        #endregion

    }
}
