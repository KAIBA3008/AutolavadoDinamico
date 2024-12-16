using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace AutolavadoMaldicion
{
    public class Cliente
    {
        private static readonly Random random = new Random();

        public string NombreCompleto { get; set; }

        public string CI { get; set; }

        public string ModeloVehiculo { get; set; }

        public bool Camioneta { get; set; }

        public string Placa { get; set; }

        public int ID { get; set; }

        public Cliente(string nombreCompleto, string ci, string modeloVehiculo, string placa, bool esCamioneta)
        {
            NombreCompleto = nombreCompleto;
            CI = ci;
            ModeloVehiculo = modeloVehiculo;
            Placa = placa;
            ID = random.Next();
            Camioneta = esCamioneta;
        }
    }
}
