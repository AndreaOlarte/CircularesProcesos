using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ED___Programa_22.CircularesProcesos
{
    class Proceso
    {
        static private Random _aleatorio = new Random(DateTime.Now.Millisecond);
        private Proceso _siguiente;
        public Proceso siguiente
        {
            get { return _siguiente; }
            set { _siguiente = value; }
        }

        private int _ciclos;
        public int ciclos
        {
            get { return _ciclos; }
            set { _ciclos = value; }
        }

        public Proceso()
        {
            _ciclos = _aleatorio.Next(4, 13);
        }
    }
}
