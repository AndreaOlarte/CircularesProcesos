using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ED___Programa_22.CircularesProcesos
{
    class Procesador
    {
        static private Random random = new Random(DateTime.Now.Millisecond);
        private Proceso _enTurno;
        private Proceso _ultimo;
        private int _vacios;
        public int vacios
        {
            get { return _vacios; }
        }
        private int _pMaximos;
        public int pMaximos
        {
            get { return _pMaximos; }
        }
        private int _pAtendidos;
        public int pAtendidos
        {
            get { return _pAtendidos; }
        }
        public void Enqueue(Proceso proceso) //Agregar
        {
            if (_ultimo == null)
            {
                _enTurno = proceso; //Cuidado
                _ultimo = proceso;
                _ultimo.siguiente = _ultimo;
            }
            else
            {
                proceso.siguiente = _ultimo.siguiente;
                _ultimo.siguiente = proceso;
                _ultimo = _ultimo.siguiente;
            }
        }

        public void Dequeue() //Borrar
        {
            if (_enTurno.siguiente == _enTurno)
            {
                _ultimo = null;
                _enTurno = null;
            }
            else
            {
                Proceso auxiliar = _ultimo.siguiente;
                while (auxiliar.siguiente != _enTurno)
                    auxiliar = auxiliar.siguiente;
                auxiliar.siguiente = _enTurno.siguiente;
            }
        }

        public void procesar(int ciclos)
        {
            _pMaximos = 0;
            _pAtendidos = 0;
            _vacios = 0;
            for (int i = 0; i < ciclos; i++)
            {
                if (_enTurno == null)
                    _vacios++;
                else if (_enTurno.ciclos != 1) //Procesar
                    _enTurno.ciclos--;
                else
                {
                    Dequeue();
                    _pAtendidos++;
                }
                
                //Agregar nuevo proceso
                if (random.Next(1, 5) == 1)
                {
                    Proceso proceso = new Proceso();
                    Enqueue(proceso);
                    _ultimo = proceso;
                    _pMaximos++;
                }

                //Pasar al siguiente enTurno
                if (_enTurno != null)
                    _enTurno = _enTurno.siguiente;
            }
        }

        public override string ToString()
        {
            int cantidad = 0;
            int ciclos = 0;
            Proceso auxiliar = _ultimo;
            do
            {
                cantidad++;
                ciclos += auxiliar.ciclos;
                auxiliar = auxiliar.siguiente;
            } while (auxiliar != _ultimo);
            return "Procesos pendientes: " + cantidad.ToString() + "\r\nSuma de los ciclos: " + ciclos.ToString();
        }
    }
}
