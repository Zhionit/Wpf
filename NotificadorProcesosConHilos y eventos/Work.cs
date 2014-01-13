using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificadorProcesosConHilos_y_eventos
{
    
    class Work
    {
        public delegate void work(string notificarion);
        public event work working;

        public void trabajando()
        {
            working("Empezando a trabajar");

            for (int i = 0; i < 1000000; i++)
            {
                if (i % 10000 == 0)
                {
                    working("Vamos en el número " + i);
                }
            }
        }
    }
}
