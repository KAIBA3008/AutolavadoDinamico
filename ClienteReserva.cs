using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace AutolavadoMaldicion
{
    public class ClienteReserva : Cliente
    {

        public bool LavadoR { get; set; }

        public bool AspiradoR { get; set; }

        public bool SecadoR { get; set; }

        public bool BalanceoR { get; set; }

        public bool AceiteR { get; set; }

        public bool EnProceso { get; set; }

        public bool Cuota1 {  get; set; }
        public bool Cuota2 { get; set; }
        public bool Cuota3 { get; set; }
        public bool Cuota4 { get; set; }

        public int ContCuouta { get; set; }


        public int PosicionDeEspera { get; set; }

        PilaString2 FacturaServicio = new PilaString2();

        PilaString2 Facturamonto = new PilaString2();

        PilaString2 Cauchos = new PilaString2();

        public float MontoCliente;

        public int CantCauchos;

        public ClienteReserva(string nombreCompleto, string ci, string modeloVehiculo, string placa, bool esCamioneta, int id, int Posicion, int XCauchos)
         : base(nombreCompleto, ci, modeloVehiculo, placa, esCamioneta)
        {
            LavadoR = false;
            AspiradoR = false;
            SecadoR = false;
            BalanceoR = false;
            AceiteR = false;
            EnProceso = false;
            PosicionDeEspera = Posicion;
            FacturaServicio = new PilaString2();
            Facturamonto = new PilaString2();
            MontoCliente = 0;
            ID = id;

            CantCauchos = XCauchos;



            Cauchos = new PilaString2();

            for (int i = 0; i < CantCauchos; i++)
            {
                Cauchos.Push("X");
            }

            Cuota1 = false;
            Cuota2 = false;
            Cuota3 = false;
            Cuota4 = false;
            ContCuouta = 0;

        }

        public void Reservacion(bool lavado, bool aspirado, bool secado, bool balanceo, bool aceite)
        {
            LavadoR = lavado;
            AspiradoR = aspirado;
            SecadoR = secado;
            BalanceoR = balanceo;
            AceiteR = aceite;
            FacturaPila();
            CalculoMonto();
        }

        public bool PilaServicioVacia()
        {

            return FacturaServicio.PilaVacia();

        }

        public void FacturaPila()
        {
            if (LavadoR)
            {
                if (Camioneta) { FacturaServicio.Push("Lavado"); Facturamonto.Push("10$"); }
                else { FacturaServicio.Push("Lavado"); Facturamonto.Push("6$"); }
            }


            if (AspiradoR)
            {
                if (Camioneta) { FacturaServicio.Push("Aspirado"); Facturamonto.Push("6$"); }
                else { FacturaServicio.Push("Aspirado"); Facturamonto.Push("4$"); }
            }


            if (SecadoR)
            {
                if (Camioneta) { FacturaServicio.Push("Secado"); Facturamonto.Push("5$"); }

                else { FacturaServicio.Push("Secado"); Facturamonto.Push("4$"); }
            }


            if (BalanceoR)
            {
                if (Camioneta) { FacturaServicio.Push("Balanceo"); Facturamonto.Push("35$"); }
                else { FacturaServicio.Push("Balanceo"); Facturamonto.Push("25$"); }
            }


            if (AceiteR)
            {
                if (Camioneta) { FacturaServicio.Push("Aceite"); Facturamonto.Push("20$"); }
                else { FacturaServicio.Push("Aceite"); Facturamonto.Push("15$"); }
            }
        }

        public float CalculoMonto()
        {
            if (LavadoR)
            {
                if (Camioneta) MontoCliente += 10;
                else MontoCliente += 6;
            }

            if (AspiradoR)
            {
                if (Camioneta) MontoCliente += 6;
                else MontoCliente += 4;
            }

            if (SecadoR)
            {
                if (Camioneta) MontoCliente += 5;
                else MontoCliente += 4;
            }

            if (BalanceoR)
            {
                if (Camioneta) MontoCliente += 35;
                else MontoCliente += 25;
            }

            if (AceiteR)
            {
                if (Camioneta) MontoCliente += 20;
                else MontoCliente += 15;
            }

            return MontoCliente;
        }

        public string FacturaPilaR()
        {
            return FacturaServicio.Pop();
        }

        public void facturaPilaPush(String x)
        {
            FacturaServicio.Push(x);
        }

        public string FacturaPilaMontoR()
        {
            return Facturamonto.Pop();
        }

        public void FacturamontoPush(string x)
        {
            Facturamonto.Push(x);
        }

        public void InvertirPila()
        {
            PilaString2 PilaAux = new PilaString2();

            for (int i = 0; i <= FacturaServicio.tope(); i++)
            {
                PilaAux.Push(FacturaServicio.Pop());

            }

            FacturaServicio = PilaAux;

        }

        public int Facturatope()
        {
            return FacturaServicio.tope();
        }

        public void PopPilaCauchos()
        {
            Cauchos.Pop();
        }

        public int CantEPilaCauchos()
        {
            return Cauchos.tope();

        }

        public string facturaPilarp(int x)
        {
            return FacturaServicio.Pilarp(x);
        }

        public int ObtenerCantidadCauchos()
        {
            return CantCauchos;

        }

    }
}
