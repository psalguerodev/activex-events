using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.ComponentModel;
using System.Windows.Forms;

namespace ExtensionActiveX
{
    public class ProcesoAsincrono : ContainerControl
    {

        public delegate void ManejadorAsincrono(string data);
        public event ManejadorAsincrono EventoAsincrono;

        public BackgroundWorker worker = new BackgroundWorker();

        public void proceso(string data) {
            Thread hilo = new Thread(() => 
            {
                Thread.CurrentThread.IsBackground = true;
                Thread.Sleep(2000);

                if (EventoAsincrono != null)
                    EventoAsincrono(String.Format("{0,-20, 0, -40}", "EVENTO ENVIADO 2 SEGUNDOS DESPUES" , data));

            });

            hilo.Start();
        }

        public void procesoback(string data)
        {
            if (worker.IsBusy != true) {
                worker.WorkerReportsProgress = true;
                worker.WorkerSupportsCancellation = false;
                worker.DoWork += DoWorkPersonal;
                worker.RunWorkerCompleted += DoWorkCompleto;
                worker.RunWorkerAsync();    
            }
            
        }

        public void DoWorkPersonal(object sender, DoWorkEventArgs eventos) {
            BackgroundWorker worker = sender as BackgroundWorker;
            Thread.Sleep(5000);
            worker.ReportProgress(100);
        }

        public void DoWorkCompleto(object sender, RunWorkerCompletedEventArgs eventos)
        {
            EventoAsincrono("PROCESO ASINCRONO TERMINADO");
            
        }


    }
}
