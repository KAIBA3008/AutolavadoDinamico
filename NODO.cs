using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutolavadoMaldicion
{
    internal class NODO 
    {
        private ClienteReserva DATO;
        private NODO NodoSiguiente; 
        private NODO NodoAnterior;
        
        public NODO(ClienteReserva Dato, NODO Siguiente, NODO Anterior)
        { 
            DATO = Dato; 
            NodoSiguiente = Siguiente;
            NodoAnterior = Anterior; 
        }
        
        public ClienteReserva Dato 
        { 
            get { return DATO; }
            private set { DATO = value; }
        }
        
        public NODO Siguiente 
        { 
            get { return NodoSiguiente; } 
            internal set { NodoSiguiente = value; } 
        } 

        public NODO Anterior 
        {
            get { return NodoAnterior; } 
            internal set { NodoAnterior = value; } 
        }

    }

}
