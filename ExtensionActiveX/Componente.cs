using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Threading;
namespace ExtensionActiveX
{
    [ProgId("ExtensionActiveX")]
    [ClassInterface(ClassInterfaceType.AutoDual)]
    [Guid("DD452733-2BD7-4BA7-883C-A756AC338A3E")]
    [ComSourceInterfaces(typeof(IEventos))]
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
            Service1 servicio = new Service1();
            servicio.EventoServicio += new Service1.ManejadorService(ejecutarEventoFormulario);
            servicio.initService();

            MessageBox.Show(String.Format(" >> Bienvenido al Componente Activex {0} sigue avanzando!!", nombre.ToUpper()), "Mensaje desde Active X", MessageBoxButtons.OK);
            ejecutarEventoFormulario("SERVICIO INICIADO >>> " + nombre.ToUpper());
        }

        public int GenerarAleatorio(string nombre){
            if (Evento != null) this.Evento("Soy el Evento gracias " + nombre.ToUpper());
            Formulario display = new Formulario();
            display.eventoFormulario += new Formulario.ManejadorFormulario(ejecutarEventoFormulario);
            display.Show();
            return (int)DateTime.Now.Ticks;
        }

        public int ProcesoAsinc(string data)
        {
            Evento("INICIANDO ASYNC");
            ProcesoAsincrono proc = new ProcesoAsincrono();
            proc.EventoAsincrono += new ProcesoAsincrono.ManejadorAsincrono(ejecutarEventoFormulario);
            proc.procesoback(data);
            return 0;
        }

        #endregion

        // Metodo que atrapa los eventos de las Clases Externas
        private void ejecutarEventoFormulario(string texto){
            if(Evento != null)
            Evento(texto);
        }

        


    }
}
