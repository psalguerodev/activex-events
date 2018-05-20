using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Windows.Forms;

namespace ExtensionActiveX
{
    partial class Service1 : ServiceBase
    {
        private System.Timers.Timer timer = null;
        private int cont = 0;
        public delegate void ManejadorService(string contador);
        public event ManejadorService EventoServicio;

        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            // TODO: agregar código aquí para iniciar el servicio.
            initService();
        }

        public void initService() {
            timer = new System.Timers.Timer();
            timer.Interval = 1000;
            timer.Enabled = true;
            timer.Elapsed += new System.Timers.ElapsedEventHandler(process_elapsed);
            timer.Start();
        }

        void process_elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            // TODO: Proceso que se hara cada cierto tiempo
            timer.Enabled = false;
            execute_process();
        }

        private void execute_process() {
            cont++;
            EventLog.WriteEntry("<< SE HA EJECUTADO EL SERVICIO PSALGUERO >> " + cont);
            timer.Enabled = true;
        }
        
        protected override void OnStop()
        {
            // TODO: agregar código aquí para realizar cualquier anulación necesaria para detener el servicio.
            EventLog.WriteEntry("SE HA DETENIDO EL SERVICIO PSALGUERO >> " + cont);
        }

        
    }
}
