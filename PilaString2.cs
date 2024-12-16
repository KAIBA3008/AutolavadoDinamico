using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutolavadoMaldicion
{
    internal class PilaString2
    {
        private NODOSTRING Tope;
        private int CantidadElementos;

        public PilaString2()
        {
            Tope = null;
            CantidadElementos = 0;
        }

        public bool PilaVacia()
        {
            return Tope == null;
        }

        public void Push(string x)
        {
            NODOSTRING nuevoNodo = new NODOSTRING(x)
            {
                SIGUIENTE = Tope
            };
            Tope = nuevoNodo;
            CantidadElementos++;
        }

        public int tope()
        {
            return CantidadElementos - 1;
        }

        public string Pop()
        {
            if (!PilaVacia())
            {
                string valor = Tope.DATO;
                Tope = Tope.SIGUIENTE;
                CantidadElementos--;
                return valor;
            }
            else
            {
                MessageBox.Show("ERROR: Pila vacía...");
                return null;
            }
        }

        public string Pilarp(int x)
        {
            if (x >= 0 && x < CantidadElementos)
            {
                NODOSTRING actual = Tope;
                for (int i = 0; i < x; i++)
                {
                    actual = actual.SIGUIENTE;
                }
                return actual.DATO;
            }
            else
            {
                MessageBox.Show("ERROR: Índice fuera de rango.");
                return null;
            }
        }
    }
}

