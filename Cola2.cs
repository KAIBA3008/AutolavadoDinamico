using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutolavadoMaldicion
{
    internal class Cola2
    {
        private NODO HEAD;
        private NODO TAIL;

        public bool[] carrito;

        public Cola2()
        {
            HEAD = null;
            TAIL = null;

            carrito = new bool[10]; for (int i = 0; i < 10; i++) { carrito[i] = false; }

        }

        public bool ColaVacia()
        {
            return HEAD == null;

        }

        public void Insertar(ClienteReserva dato)
        {
            NODO nuevo = new NODO(dato, null, TAIL);

            if (TAIL != null) { TAIL.Siguiente = nuevo; }

            TAIL = nuevo;

            if (HEAD == null) { HEAD = nuevo; }

        }

        public ClienteReserva Retirar()
        {
            if (HEAD == null)
            {
                MessageBox.Show("ERROR: La cola está vacía.");
                return null;
            }

            ClienteReserva datoEliminado = HEAD.Dato;
            HEAD = HEAD.Siguiente;

            if (HEAD == null)
            {
                TAIL = null;
            }
            else
            {
                HEAD.Anterior = null;
            }

            return datoEliminado;
        }

        public ClienteReserva RetirarSinPop()
        {
            if (HEAD == null)
            {
                MessageBox.Show("ERROR: La cola está vacía.");
                return null;
            }
            return HEAD.Dato;
        }

        public void RetirarEspecifco(int posicion)
        {
            if (posicion < 0 || posicion >= Cantidad()) throw new ArgumentOutOfRangeException("Posición fuera de rango.");

            if (posicion == 0)
            {
                Retirar();
                return;
            }

            NODO actual = HEAD;

            for (int i = 0; i < posicion - 1; i++)
            {
                actual = actual.Siguiente;
            }

            NODO nodoAEliminar = actual.Siguiente;
            actual.Siguiente = nodoAEliminar.Siguiente;

            if (nodoAEliminar.Siguiente != null) { nodoAEliminar.Siguiente.Anterior = actual; }
            else { TAIL = actual; }
        }

        public ClienteReserva ColapR(int posicion)
        {
            if (posicion < 0 || posicion >= Cantidad()) throw new ArgumentOutOfRangeException("Posición fuera de rango.");
            NODO actual = HEAD;
            for (int i = 0; i < posicion; i++) { actual = actual.Siguiente; }
            return actual.Dato;
        }

        public int Cantidad()
        {
            int contador = 0;

            NODO actual = HEAD;

            while (actual != null) { contador++; actual = actual.Siguiente; }

            return contador;
        }

        public void Carro()
        {
            for (int i = 0; i < 10; i++) { carrito[i] = false; }
            for (int i = 0; i < Cantidad(); i++) { carrito[i] = true; }
        }

        public string Nombre(int X)
        {
            return ColapR(X).NombreCompleto;
        }

        public int ID(int X)
        {
            return ColapR(X).ID;
        }

        public string CI(int X)
        {
            return ColapR(X).CI;
        }

        public string Placa(int X)
        {
            return ColapR(X).Placa;
        }

        public string ModeloVehiculo(int X)
        {
            return ColapR(X).ModeloVehiculo;
        }

        public bool NoEsElUltimo(int posicion)
        {
            if (posicion < 0 || posicion >= Cantidad()) throw new ArgumentOutOfRangeException("La posición no puede ser negativa o mayor que la cantidad de nodos.");
            return posicion < Cantidad() - 1;

        }

        public NODO BuscarPorPlaca(string Placa)
        {
            NODO actual = HEAD;
            while (actual != null)
            {
                if (actual.Dato.Placa == Placa)
                {
                    return actual;
                }

                actual = actual.Siguiente;

            }
            return null;

        }
    }
}
