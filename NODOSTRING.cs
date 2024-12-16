using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutolavadoMaldicion
{
    internal class NODOSTRING
    {
        private string Dato;
        private NODOSTRING Siguiente;
        private NODOSTRING Anterior;

        public NODOSTRING(string dato)
        {
            Dato = dato;
            Siguiente = null;
            Anterior = null;
        }

        public string DATO
        {
            get { return Dato; }
            set { Dato = value; }
        }

        public NODOSTRING SIGUIENTE
        {
            get { return Siguiente; }
            set { Siguiente = value; }
        }

        public NODOSTRING ANTERIOR
        {
            get { return Anterior; }
            set { Anterior = value; }
        }
    }
}

