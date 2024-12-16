using AutolavadoMaldicion.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using MaterialSkin2Framework.Controls;
using MaterialSkin2Framework;
using System.Media;
using System.IO;

namespace AutolavadoMaldicion
{
    public partial class Form1 : MaterialForm
    {
        List<Cliente> Planilla;
        List<ClienteReserva> PlanillaReservas;
        Cola2 ColaLavado = new Cola2();
        Cola2 ColaAspirado = new Cola2();
        Cola2 ColaSecado = new Cola2();
        Cola2 ColaAceite = new Cola2();
        Cola2 ColaCauchos = new Cola2();
        Cola2 ColaFactura = new Cola2();
        Cola2 ColaPagos = new Cola2();

        int ContHoja;
        int ContHojaPago;
        int ContEspera;
        int ContCauchos = 4;

        bool factura1 = false;
        bool factura2 = false;
        bool factura3 = false;
        bool factura4 = false;
        bool factura5 = false;
        bool factura6 = false;
        bool factura7 = false;
        bool factura8 = false;
        bool factura9 = false;
        bool factura10 = false;

        bool grafico = false;
        bool carroBalanceando = false;

        private ToolTip toolTip0 = new ToolTip();
        private ToolTip toolTip1 = new ToolTip();
        private ToolTip toolTip2 = new ToolTip();
        private ToolTip toolTip3 = new ToolTip();
        private ToolTip toolTip4 = new ToolTip();
        private ToolTip toolTip5 = new ToolTip();
        private ToolTip toolTip6 = new ToolTip();
        private ToolTip toolTip7 = new ToolTip();
        private ToolTip toolTip8 = new ToolTip();
        private ToolTip toolTip9 = new ToolTip();

        private ToolTip toolTip10 = new ToolTip();
        private ToolTip toolTip11 = new ToolTip();
        private ToolTip toolTip12 = new ToolTip();
        private ToolTip toolTip13 = new ToolTip();
        private ToolTip toolTip14 = new ToolTip();
        private ToolTip toolTip15 = new ToolTip();
        private ToolTip toolTip16 = new ToolTip();
        private ToolTip toolTip17 = new ToolTip();
        private ToolTip toolTip18 = new ToolTip();
        private ToolTip toolTip19 = new ToolTip();

        private ToolTip toolTip20 = new ToolTip();
        private ToolTip toolTip21 = new ToolTip();
        private ToolTip toolTip22 = new ToolTip();
        private ToolTip toolTip23 = new ToolTip();
        private ToolTip toolTip24 = new ToolTip();
        private ToolTip toolTip25 = new ToolTip();
        private ToolTip toolTip26 = new ToolTip();
        private ToolTip toolTip27 = new ToolTip();
        private ToolTip toolTip28 = new ToolTip();
        private ToolTip toolTip29 = new ToolTip();

        private ToolTip toolTip30 = new ToolTip();
        private ToolTip toolTip31 = new ToolTip();
        private ToolTip toolTip32 = new ToolTip();
        private ToolTip toolTip33 = new ToolTip();
        private ToolTip toolTip34 = new ToolTip();

        private ToolTip toolTip35 = new ToolTip();
        private ToolTip toolTip36 = new ToolTip();
        private ToolTip toolTip37 = new ToolTip();
        private ToolTip toolTip38 = new ToolTip();
        private ToolTip toolTip39 = new ToolTip();

        SoundPlayer TV = new SoundPlayer(Properties.Resources.SonidoTV);

        public Form1()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Blue100, Primary.Blue100, Primary.Blue100, Accent.LightBlue100, TextShade.WHITE);

            Planilla = new List<Cliente>();
            PlanillaReservas = new List<ClienteReserva>();
            CargaInicial();


        }

        ///////////////////////////////////////////////////Funciones varias////////////////////////////////////////////////////////////

        private void CargaInicial()
        {

            Cliente b = new Cliente("Santiago Aparcedo", "31984523", "Lancer", "dh345dsf", false);
            Planilla.Add(b);
            Cliente c = new Cliente("Raimundo Atienza", "33455719", "Aveo", "dasd9183", false);
            Planilla.Add(c);
            Cliente d = new Cliente("Georges Chakour", "54675719", "Ford", "sdf6183", true);
            Planilla.Add(d);
            Cliente e = new Cliente("Luis Alvarez", "31982349", "Ford", "ghjk6183", true);
            Planilla.Add(e);
            Cliente f = new Cliente("Tomas Alvarado", "290719", "Moto", "32hjk83", false);
            Planilla.Add(f);
            Cliente g = new Cliente("Rami Alramah", "28785719", "Ford", "asd6183", true);
            Planilla.Add(g);
            Cliente h = new Cliente("Carlos Rodriguez", "71985719", "Aveo", "ahjk83", false);
            Planilla.Add(h);
            Cliente i = new Cliente("Julio Noriega", "435985719", "moto", "2dvbn83", false);
            Planilla.Add(i);
            Cliente j = new Cliente("Leonardo Ortiz", "319345719", "Aveo", "ddsfg183", true);
            Planilla.Add(j);
            Cliente k = new Cliente("Manira Djamele", "3345985719", "Aveo", "dhkjl83", true);
            Planilla.Add(k);
            Cliente l = new Cliente("Ariana Rivera", "3455719", "Aveo", "dhsdfg83", false);
            Planilla.Add(l);
            Cliente m = new Cliente("Eliannis Huchet", "3675719", "Aveo", "d546383", true);

        }

        private void CargarPlanilla()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = Planilla;
            dataGridView2.DataSource = null;
            dataGridView2.DataSource = PlanillaReservas;
        }

        private void CargarFacturaIzq(Cola2 ColaFac, int x)
        {

            textBox75.Text = ColaFac.Nombre(x);
            textBox3.Text = ColaFac.CI(x);
            textBox4.Text = ColaFac.Placa(x);
            textBox5.Text = ColaFac.ModeloVehiculo(x);
            textBox16.Text = Convert.ToString(ColaFac.ID(x) + 1243);

            if (!ColaFac.ColapR(x).PilaServicioVacia()) { textBox85.Text = ColaFac.ColapR(x).FacturaPilaR(); textBox76.Text = ColaFac.ColapR(x).FacturaPilaMontoR(); textBox91.Visible = true; factura1 = true; }
            if (!ColaFac.ColapR(x).PilaServicioVacia()) { textBox82.Text = ColaFac.ColapR(x).FacturaPilaR(); textBox78.Text = ColaFac.ColapR(x).FacturaPilaMontoR(); textBox90.Visible = true; factura2 = true; }
            if (!ColaFac.ColapR(x).PilaServicioVacia()) { textBox83.Text = ColaFac.ColapR(x).FacturaPilaR(); textBox77.Text = ColaFac.ColapR(x).FacturaPilaMontoR(); textBox89.Visible = true; factura3 = true; }
            if (!ColaFac.ColapR(x).PilaServicioVacia()) { textBox84.Text = ColaFac.ColapR(x).FacturaPilaR(); textBox80.Text = ColaFac.ColapR(x).FacturaPilaMontoR(); textBox88.Visible = true; factura4 = true; }
            if (!ColaFac.ColapR(x).PilaServicioVacia()) { textBox81.Text = ColaFac.ColapR(x).FacturaPilaR(); textBox79.Text = ColaFac.ColapR(x).FacturaPilaMontoR(); textBox86.Visible = true; factura5 = true; }

            textBox9.Text = Convert.ToString(ColaFac.ColapR(x).MontoCliente) + "$";
            ReCargarFacturaIzq(ColaFac, x);
        }

        private void ReCargarFacturaIzq(Cola2 Factura, int x)
        {

            if (factura1) { Factura.ColapR(x).facturaPilaPush(textBox85.Text); Factura.ColapR(x).FacturamontoPush(textBox76.Text); textBox91.Visible = true; factura1 = false; }
            if (factura2) { Factura.ColapR(x).facturaPilaPush(textBox82.Text); Factura.ColapR(x).FacturamontoPush(textBox78.Text); textBox90.Visible = true; factura2 = false; }
            if (factura3) { Factura.ColapR(x).facturaPilaPush(textBox83.Text); Factura.ColapR(x).FacturamontoPush(textBox77.Text); textBox89.Visible = true; factura3 = false; }
            if (factura4) { Factura.ColapR(x).facturaPilaPush(textBox84.Text); Factura.ColapR(x).FacturamontoPush(textBox80.Text); textBox88.Visible = true; factura4 = false; }
            if (factura5) { Factura.ColapR(x).facturaPilaPush(textBox81.Text); Factura.ColapR(x).FacturamontoPush(textBox79.Text); textBox86.Visible = true; factura5 = false; }
        }

        private void CargarFacturaDer(Cola2 ColaFac, int y)
        {

            textBox54.Text = ColaFac.Nombre(y);
            textBox6.Text = ColaFac.CI(y);
            textBox8.Text = ColaFac.Placa(y);
            textBox7.Text = ColaFac.ModeloVehiculo(y);
            textBox17.Text = Convert.ToString(ColaFac.ID(y) + 1243);

            if (!ColaFac.ColapR(y).PilaServicioVacia()) { textBox61.Text = ColaFac.ColapR(y).FacturaPilaR(); textBox55.Text = ColaFac.ColapR(y).FacturaPilaMontoR(); textBox67.Visible = true; factura6 = true; }
            if (!ColaFac.ColapR(y).PilaServicioVacia()) { textBox58.Text = ColaFac.ColapR(y).FacturaPilaR(); textBox56.Text = ColaFac.ColapR(y).FacturaPilaMontoR(); textBox66.Visible = true; factura7 = true; }
            if (!ColaFac.ColapR(y).PilaServicioVacia()) { textBox59.Text = ColaFac.ColapR(y).FacturaPilaR(); textBox52.Text = ColaFac.ColapR(y).FacturaPilaMontoR(); textBox65.Visible = true; factura8 = true; }
            if (!ColaFac.ColapR(y).PilaServicioVacia()) { textBox60.Text = ColaFac.ColapR(y).FacturaPilaR(); textBox53.Text = ColaFac.ColapR(y).FacturaPilaMontoR(); textBox64.Visible = true; factura9 = true; }
            if (!ColaFac.ColapR(y).PilaServicioVacia()) { textBox57.Text = ColaFac.ColapR(y).FacturaPilaR(); textBox51.Text = ColaFac.ColapR(y).FacturaPilaMontoR(); textBox62.Visible = true; factura10 = true; }

            textBox10.Text = Convert.ToString(ColaFac.ColapR(y).MontoCliente) + "$";
            ReCargarFacturaDer(ColaFac, y);

        }

        private void ReCargarFacturaDer(Cola2 Factura, int y)
        {

            if (factura6) { Factura.ColapR(y).facturaPilaPush(textBox61.Text); Factura.ColapR(y).FacturamontoPush(textBox55.Text); textBox67.Visible = true; factura6 = false; }
            if (factura7) { Factura.ColapR(y).facturaPilaPush(textBox58.Text); Factura.ColapR(y).FacturamontoPush(textBox56.Text); textBox66.Visible = true; factura7 = false; }
            if (factura8) { Factura.ColapR(y).facturaPilaPush(textBox59.Text); Factura.ColapR(y).FacturamontoPush(textBox52.Text); textBox65.Visible = true; factura8 = false; }
            if (factura9) { Factura.ColapR(y).facturaPilaPush(textBox60.Text); Factura.ColapR(y).FacturamontoPush(textBox53.Text); textBox64.Visible = true; factura9 = false; }
            if (factura10) { Factura.ColapR(y).facturaPilaPush(textBox57.Text); Factura.ColapR(y).FacturamontoPush(textBox51.Text); textBox62.Visible = true; factura10 = false; }
        }

        private void LimpiarFactura()
        {
            textBox75.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
            textBox5.Text = null;

            textBox85.Text = null; textBox76.Text = null; textBox91.Visible = false;
            textBox82.Text = null; textBox78.Text = null; textBox90.Visible = false;
            textBox83.Text = null; textBox77.Text = null; textBox89.Visible = false;
            textBox84.Text = null; textBox80.Text = null; textBox88.Visible = false;
            textBox81.Text = null; textBox79.Text = null; textBox86.Visible = false;
            textBox9.Text = null;

            textBox54.Text = null;
            textBox6.Text = null;
            textBox8.Text = null;
            textBox7.Text = null;

            textBox61.Text = null; textBox55.Text = null; textBox67.Visible = false;
            textBox58.Text = null; textBox56.Text = null; textBox66.Visible = false;
            textBox59.Text = null; textBox52.Text = null; textBox65.Visible = false;
            textBox60.Text = null; textBox53.Text = null; textBox64.Visible = false;
            textBox57.Text = null; textBox51.Text = null; textBox62.Visible = false;
            textBox10.Text = null;

            textBox16.Text = null; textBox17.Text = null;

        }

        private void CargarPagosIzq(Cola2 ColaPagos, int x)
        {

            textBox11.Text = ColaPagos.Nombre(x);
            textBox19.Text = ColaPagos.CI(x);
            textBox21.Text = ColaPagos.Placa(x);
            textBox12.Text = ColaPagos.ModeloVehiculo(x);
            textBox122.Text = Convert.ToString(ColaPagos.ID(x) + 1243);
            textBox42.Text = Convert.ToString(ColaPagos.ColapR(x).MontoCliente) + "$";

            textBox30.Text = Convert.ToString(ColaPagos.ColapR(x).MontoCliente / 4) + "$";
            textBox33.Text = Convert.ToString(ColaPagos.ColapR(x).MontoCliente / 4) + "$";
            textBox32.Text = Convert.ToString(ColaPagos.ColapR(x).MontoCliente / 4) + "$";
            textBox31.Text = Convert.ToString(ColaPagos.ColapR(x).MontoCliente / 4) + "$";

            ClienteReserva X = ColaPagos.BuscarPorPlaca(textBox21.Text).Dato;
            if (X.Cuota1 == true) { textBox37.Font = new Font(textBox37.Font, FontStyle.Strikeout); }
            if (X.Cuota2 == true) { textBox34.Font = new Font(textBox34.Font, FontStyle.Strikeout); }
            if (X.Cuota3 == true) { textBox36.Font = new Font(textBox36.Font, FontStyle.Strikeout); }
            if (X.Cuota4 == true) { textBox35.Font = new Font(textBox35.Font, FontStyle.Strikeout); }

            if (X.Cuota1 == true && X.Cuota2 == true && X.Cuota3 == true && X.Cuota4 == true) { textBox125.Font = new Font(textBox125.Font, FontStyle.Strikeout); }

            textBox38.Text = Convert.ToString((ColaPagos.ColapR(x).MontoCliente / 4)*ColaPagos.ColapR(x).ContCuouta) + "$";
            textBox40.Text = Convert.ToString(ColaPagos.ColapR(x).MontoCliente - ((ColaPagos.ColapR(x).MontoCliente / 4) * ColaPagos.ColapR(x).ContCuouta)) + "$";


            textBox37.Visible = true;
            textBox34.Visible = true;
            textBox35.Visible = true;
            textBox36.Visible = true;
            textBox125.Visible = true;

        }

        private void CargarPagosDer(Cola2 ColaPagos, int x)
        {

            textBox116.Text = ColaPagos.Nombre(x);
            textBox106.Text = ColaPagos.CI(x);
            textBox102.Text = ColaPagos.Placa(x);
            textBox110.Text = ColaPagos.ModeloVehiculo(x);
            textBox124.Text = Convert.ToString(ColaPagos.ID(x) + 1243);
            textBox47.Text = Convert.ToString(ColaPagos.ColapR(x).MontoCliente) + "$";

            textBox115.Text = Convert.ToString(ColaPagos.ColapR(x).MontoCliente / 4) + "$";
            textBox120.Text = Convert.ToString(ColaPagos.ColapR(x).MontoCliente / 4) + "$";
            textBox118.Text = Convert.ToString(ColaPagos.ColapR(x).MontoCliente / 4) + "$";
            textBox117.Text = Convert.ToString(ColaPagos.ColapR(x).MontoCliente / 4) + "$";


            ClienteReserva X = ColaPagos.BuscarPorPlaca(textBox102.Text).Dato;
            if (X.Cuota1 == true) { textBox119.Font = new Font(textBox119.Font, FontStyle.Strikeout); }
            if (X.Cuota2 == true) { textBox46.Font = new Font(textBox46.Font, FontStyle.Strikeout); }
            if (X.Cuota3 == true) { textBox45.Font = new Font(textBox45.Font, FontStyle.Strikeout); }
            if (X.Cuota4 == true) { textBox44.Font = new Font(textBox44.Font, FontStyle.Strikeout); }

            if (X.Cuota1 == true && X.Cuota2 == true && X.Cuota3 == true && X.Cuota4 == true) { textBox126.Font = new Font(textBox126.Font, FontStyle.Strikeout); }


            textBox119.Visible = true;
            textBox46.Visible = true;
            textBox45.Visible = true;
            textBox44.Visible = true;
            textBox126.Visible = true;

            textBox99.Text = Convert.ToString((ColaPagos.ColapR(x).MontoCliente / 4) * ColaPagos.ColapR(x).ContCuouta) + "$";
            textBox49.Text = Convert.ToString(ColaPagos.ColapR(x).MontoCliente - ((ColaPagos.ColapR(x).MontoCliente / 4) * ColaPagos.ColapR(x).ContCuouta)) + "$";

        }

        private void LimpiarPagos()
        {
            textBox11.Text = null;
            textBox19.Text = null;
            textBox12.Text = null;
            textBox21.Text = null;
            textBox30.Text = null;
            textBox33.Text = null;
            textBox32.Text = null;
            textBox31.Text = null;
            textBox38.Text = null;
            textBox40.Text = null;
            textBox42.Text = null;
            textBox122.Text = null;
            textBox37.Font = new Font(textBox37.Font.FontFamily, textBox37.Font.Size, FontStyle.Regular);
            textBox34.Font = new Font(textBox34.Font.FontFamily, textBox34.Font.Size, FontStyle.Regular);
            textBox36.Font = new Font(textBox36.Font.FontFamily, textBox36.Font.Size, FontStyle.Regular);
            textBox35.Font = new Font(textBox35.Font.FontFamily, textBox35.Font.Size, FontStyle.Regular);
            textBox125.Font = new Font(textBox125.Font.FontFamily, textBox125.Font.Size, FontStyle.Regular);

            textBox116.Text = null;
            textBox106.Text = null;
            textBox110.Text = null;
            textBox102.Text = null;
            textBox115.Text = null;
            textBox120.Text = null;
            textBox118.Text = null;
            textBox117.Text = null;
            textBox99.Text = null;
            textBox49.Text = null;
            textBox47.Text = null;
            textBox124.Text = null;
            textBox119.Font = new Font(textBox119.Font.FontFamily, textBox119.Font.Size, FontStyle.Regular);
            textBox46.Font = new Font(textBox46.Font.FontFamily, textBox46.Font.Size, FontStyle.Regular);
            textBox45.Font = new Font(textBox45.Font.FontFamily, textBox45.Font.Size, FontStyle.Regular);
            textBox44.Font = new Font(textBox44.Font.FontFamily, textBox44.Font.Size, FontStyle.Regular);
            textBox126.Font = new Font(textBox126.Font.FontFamily, textBox126.Font.Size, FontStyle.Regular);

            textBox37.Visible = false;
            textBox34.Visible = false;
            textBox35.Visible = false;
            textBox36.Visible = false;
            textBox125.Visible = false;
            textBox119.Visible = false;
            textBox46.Visible = false;
            textBox45.Visible = false;
            textBox44.Visible = false;
            textBox126.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            TV.PlayLooping();
        }

        private void AdapatarEspera()
        {
            for (int i = 0; i < PlanillaReservas.Count; i++)
            {
                if (PlanillaReservas[i].PosicionDeEspera >= 1)
                {
                    PlanillaReservas[i].PosicionDeEspera--;
                }
                else { PlanillaReservas.Remove(PlanillaReservas[i]); }
            }


        }

        private void BuscarCliente()
        {
            List<ClienteReserva> PlanillaFiltradaCliente = new List<ClienteReserva>();

            var PlanillaFiltrada = PlanillaReservas.Where(ClienteReserva => Convert.ToString(ClienteReserva.ID).StartsWith(textBox14.Text));

            PlanillaFiltradaCliente = PlanillaFiltrada.ToList();

            dataGridView2.DataSource = null;
            dataGridView2.DataSource = PlanillaFiltradaCliente;
        }

        private void Cauchos(int numCauchos)
        {

                switch (numCauchos)
                {

                    case 0:
                        pictureBox53.Visible = false;
                        pictureBox51.Visible = false;
                        pictureBox54.Visible = false;
                        pictureBox52.Visible = false;
                        break;

                    case 1:
                        pictureBox53.Visible = false;
                        pictureBox51.Visible = false;
                        pictureBox54.Visible = false;
                        pictureBox52.Visible = true;
                        break;

                    case 2:
                        pictureBox53.Visible = false;
                        pictureBox51.Visible = false;
                        pictureBox54.Visible = true;
                        pictureBox52.Visible = true;
                        break;

                    case 3:
                        pictureBox53.Visible = false;
                        pictureBox51.Visible = true;
                        pictureBox54.Visible = true;
                        pictureBox52.Visible = true;
                        break;

                    case 4:
                        pictureBox53.Visible = true;
                        pictureBox51.Visible = true;
                        pictureBox54.Visible = true;
                        pictureBox52.Visible = true;
                        break;

                }
        }


        /////////////////////////////////////////////////////////Registrar Clientes////////////////////////////////////////////////////////
        
        private void materialFloatingActionButton1_Click(object sender, EventArgs e)
        {

            panel2.Visible = false;
           // pictureBox66.Image = Resources.Exito;
            //pictureBox66.Image = Resources.Gif1_TV3;

            Cliente cliente = new Cliente(
                materialMaskedTextBox1.Text,
                materialMaskedTextBox2.Text,
                materialMaskedTextBox3.Text,
                materialMaskedTextBox4.Text,
                materialRadioButton1.Checked
            );

            Planilla.Add(cliente);
            CargarPlanilla();
        }


        /////////////////////////////////////////////////////////////Hacer una Reserva//////////////////////////////////////////////////////

        private void materialFloatingActionButton2_Click(object sender, EventArgs e)
        {
            if (PlanillaReservas.Count == 0)
            {
                ContEspera = 0;
            }

            ContEspera++;

            int id;
            if (!int.TryParse(materialMaskedTextBox8.Text, out id))
            {
                MessageBox.Show("Debes introducir una ID válida.");
                return;
            }

            var indice = Planilla.FindIndex(Cliente => Cliente.ID.Equals(id));
            if (indice < 0)
            {
                MessageBox.Show("Cliente no encontrado");
                return;
            }

            int textBoxValue = 0;
            if (materialCheckbox5.Checked)
            {
                if (!int.TryParse(textBox2.Text, out textBoxValue) || (textBoxValue < 1 || textBoxValue > 4))
                {
                    MessageBox.Show("Debes introducir un valor entre 1 y 4 en textBox2.");
                    return;
                }
            }

            ClienteReserva Clientesito = new ClienteReserva(
                Planilla[indice].NombreCompleto,
                Planilla[indice].CI,
                Planilla[indice].ModeloVehiculo,
                Planilla[indice].Placa,
                Planilla[indice].Camioneta,
                Planilla[indice].ID,
                ContEspera,
                textBoxValue
            );

            Clientesito.Reservacion(
                materialCheckbox1.Checked,
                materialCheckbox2.Checked,
                materialCheckbox3.Checked,
                materialCheckbox5.Checked,
                materialCheckbox6.Checked);

            PlanillaReservas.Add(Clientesito);
            CargarPlanilla();
            panel3.Visible = false;
        }


        /////////////////////////////////////////////////////////////Botones de Interfaz///////////////////////////////////////////////////////////

        private void pictureBox35_Click(object sender, EventArgs e)
        {
            if (ColaFactura.ColaVacia())
            {
                return;
            }
            if (ContHoja + 2 >= ColaFactura.Cantidad())
            {
                return;
            }

            LimpiarFactura();
            ContHoja += 2;

            CargarFacturaIzq(ColaFactura, ContHoja);


            Random rnd = new Random();
            int sonidoAleatorio = rnd.Next(1, 3);

            Stream sonido;
            if (sonidoAleatorio == 1)
            {
                sonido = Properties.Resources.Pagina;
            }
            else
            {
                sonido = Properties.Resources.Pagina2;
            }

            SoundPlayer player = new SoundPlayer(sonido);
            player.Play();


            if (ColaFactura.NoEsElUltimo(ContHoja))
            {
                CargarFacturaDer(ColaFactura, ContHoja + 1);


                Random rnd2 = new Random();
                int sonidoAleatorio2 = rnd2.Next(1, 3);

                Stream sonido2;
                if (sonidoAleatorio2 == 1)
                {
                    sonido2 = Properties.Resources.Pagina;
                }
                else
                {
                    sonido2 = Properties.Resources.Pagina2;
                }

                SoundPlayer player2 = new SoundPlayer(sonido2);
                player2.Play();

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (button5.Visible)
            {
                Stream sonido = Properties.Resources.Biblioteca;
                SoundPlayer player = new SoundPlayer(sonido);
                player.Play();

                button5.Visible = false;
                button12.Visible = true;

                if (!panel9.Visible) { panel9.Visible = !panel9.Visible; }
                else { panel9.Visible = !panel9.Visible; }

            }

            if (ColaPagos.Cantidad() > 0)
            {
                ContHojaPago = 0;

                CargarPagosIzq(ColaPagos, ContHojaPago);
                if (ColaPagos.NoEsElUltimo(ContHojaPago)) { CargarPagosDer(ColaPagos, ContHojaPago + 1); }

            }
        }

        private void pictureBox38_Click(object sender, EventArgs e)
        {

            if (ContHoja != 0)
            {
                LimpiarFactura();
                ContHoja = ContHoja - 2;

                CargarFacturaIzq(ColaFactura, ContHoja);

                Random rnd = new Random();
                int sonidoAleatorio = rnd.Next(1, 3);

                Stream sonido;
                if (sonidoAleatorio == 1)
                {
                    sonido = Properties.Resources.Pagina;
                }
                else
                {
                    sonido = Properties.Resources.Pagina2;
                }

                SoundPlayer player = new SoundPlayer(sonido);
                player.Play();




                if (ColaFactura.NoEsElUltimo(ContHoja)) 
                {
                    CargarFacturaDer(ColaFactura, ContHoja + 1);

                    Random rnd2 = new Random();
                    int sonidoAleatorio2 = rnd2.Next(1, 3);
                    Stream sonido2;
                    if (sonidoAleatorio2 == 1)
                    {
                        sonido2 = Properties.Resources.Pagina;
                    }
                    else
                    {
                        sonido2 = Properties.Resources.Pagina2;
                    }

                    SoundPlayer player2 = new SoundPlayer(sonido2);
                    player2.Play();

                }
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (!panel7.Visible) { panel7.Visible = !panel7.Visible; }
            else { panel7.Visible = !panel7.Visible; }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (!panel2.Visible) { panel2.Visible = !panel2.Visible; }
            else { panel2.Visible = !panel2.Visible; }

        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (grafico == true) 
            {
                grafico = false; 
                panel8.Visible = false; 
                panel1.Visible = true; 
                button9.BackgroundImage = Resources.PerillaPrime1;

                Stream sonido = Properties.Resources.Perilla21; 
                SoundPlayer player = new SoundPlayer(sonido);
                player.Play();

            }
            else 
            {
                grafico = true;
                panel8.Visible = true;
                panel1.Visible = false;
                button9.BackgroundImage = Resources.PerillaPrime1Cambio;


                Stream sonido = Properties.Resources.Perilla21;
                SoundPlayer player = new SoundPlayer(sonido);
                player.Play();

            }
            CargarPlanilla();
        }

        private async void button10_Click(object sender, EventArgs e)
        {
            pictureBox76.Visible = !pictureBox76.Visible;

            if (pictureBox76.Visible)
            {
               button10.BackgroundImage = Resources.Perilla2Prime;
               Stream sonido2 = Properties.Resources.Perilla;
               SoundPlayer player2 = new SoundPlayer(sonido2);
               player2.Play();
               await Task.Delay(600);
               TV.PlayLooping();

            }
            else
            {
              TV.Stop();
              button10.BackgroundImage = Resources.Perilla2PrimeCambio;
              Stream sonido2 = Properties.Resources.Perilla;
              SoundPlayer player2 = new SoundPlayer(sonido2);
              player2.Play();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!panel3.Visible) { panel3.Visible = !panel3.Visible; }
            else { panel3.Visible = !panel3.Visible; }
        }

        private void materialCheckbox1_Click(object sender, EventArgs e)
        {
            if (materialCheckbox4.Checked) { materialCheckbox4.Checked = false; }
            if (materialCheckbox7.Checked) { materialCheckbox7.Checked = false; }
        }

        private void materialCheckbox4_Click(object sender, EventArgs e)
        {
            if (materialCheckbox4.Checked) { materialCheckbox1.Checked = true; materialCheckbox2.Checked = true; materialCheckbox3.Checked = true; materialCheckbox5.Checked = false; materialCheckbox6.Checked = false; materialCheckbox7.Checked = false; }
            else { materialCheckbox1.Checked = false; materialCheckbox2.Checked = false; materialCheckbox3.Checked = false; }
        }

        private void materialCheckbox2_Click(object sender, EventArgs e)
        {
            if (materialCheckbox4.Checked) { materialCheckbox4.Checked = false; }
            if (materialCheckbox7.Checked) { materialCheckbox7.Checked = false; }
        }

        private void materialCheckbox3_Click(object sender, EventArgs e)
        {
            if (materialCheckbox4.Checked) { materialCheckbox4.Checked = false; }
            if (materialCheckbox7.Checked) { materialCheckbox7.Checked = false; }
        }

        private void materialCheckbox7_Click(object sender, EventArgs e)
        {
            if (materialCheckbox7.Checked) { materialCheckbox1.Checked = true; materialCheckbox2.Checked = true; materialCheckbox3.Checked = true; materialCheckbox4.Checked = false; materialCheckbox5.Checked = true; materialCheckbox6.Checked = true; }
            else { materialCheckbox1.Checked = false; materialCheckbox2.Checked = false; materialCheckbox3.Checked = false; materialCheckbox5.Checked = false; materialCheckbox6.Checked = false; }
        }

        private void materialCheckbox5_Click(object sender, EventArgs e)
        {
            if (materialCheckbox7.Checked) { materialCheckbox7.Checked = false; }
        }

        private void materialCheckbox6_Click(object sender, EventArgs e)
        {
            if (materialCheckbox7.Checked) { materialCheckbox7.Checked = false; }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (button7.Visible)
            {
                Stream sonido = Properties.Resources.Biblioteca;
                SoundPlayer player = new SoundPlayer(sonido);
                player.Play();

                button7.Visible = false;
                button11.Visible = true;

                if (!panel4.Visible) { panel4.Visible = true; }
                else { panel4.Visible = false; }
            }

            if (ColaFactura.Cantidad() > 0)
            {
                ContHoja = 0;

                CargarFacturaIzq(ColaFactura, ContHoja);
                if (ColaFactura.NoEsElUltimo(ContHoja))
                {
                    CargarFacturaDer(ColaFactura, ContHoja + 1);
                }
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            panel4.Visible = false;
            button11.Visible = false;
            button7.Visible = true;

            Stream sonido = Properties.Resources.Biblioteca;
            SoundPlayer player = new SoundPlayer(sonido);
            player.Play();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!panel5.Visible) { panel5.Visible = !panel5.Visible; }
            else { panel5.Visible = !panel5.Visible; }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!panel6.Visible) { panel6.Visible = !panel6.Visible; }
            else { panel6.Visible = !panel6.Visible; }
        }

        private void materialCheckbox5_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.Visible = materialCheckbox5.Checked;
        }

        private void pictureBox62_Click(object sender, EventArgs e)
        {
            var pago = ColaPagos.BuscarPorPlaca(textBox21.Text).Dato;

            if (pago != null)
            {
                pago.Cuota1 = true;
                textBox37.Font = new Font(textBox37.Font, FontStyle.Strikeout);
                pago.ContCuouta += 1;

                var montoCliente = pago.MontoCliente;

                textBox38.Text = ((montoCliente / 4) * pago.ContCuouta).ToString() + "$";
                textBox40.Text = (montoCliente - ((montoCliente / 4) * pago.ContCuouta)).ToString() + "$";

                if (pago.Cuota1 && pago.Cuota2 && pago.Cuota3 && pago.Cuota4)
                {
                    textBox125.Font = new Font(textBox125.Font, FontStyle.Strikeout);
                }
            }
        }

        private void pictureBox63_Click(object sender, EventArgs e)
        {
            var pago = ColaPagos.BuscarPorPlaca(textBox21.Text).Dato;

            if (pago != null)
            {
                pago.Cuota2 = true;
                textBox34.Font = new Font(textBox34.Font, FontStyle.Strikeout);
                pago.ContCuouta += 1;

                var montoCliente = pago.MontoCliente;

                textBox38.Text = ((montoCliente / 4) * pago.ContCuouta).ToString() + "$";
                textBox40.Text = (montoCliente - ((montoCliente / 4) * pago.ContCuouta)).ToString() + "$";

                if (pago.Cuota1 && pago.Cuota2 && pago.Cuota3 && pago.Cuota4)
                {
                    textBox125.Font = new Font(textBox125.Font, FontStyle.Strikeout);
                }
            }
        }

        private void pictureBox78_Click(object sender, EventArgs e)
        {
            var pago = ColaPagos.BuscarPorPlaca(textBox21.Text).Dato;

            if (pago != null)
            {
                pago.Cuota3 = true;
                textBox36.Font = new Font(textBox36.Font, FontStyle.Strikeout);
                pago.ContCuouta += 1;

                var montoCliente = pago.MontoCliente;

                textBox38.Text = ((montoCliente / 4) * pago.ContCuouta).ToString() + "$";
                textBox40.Text = (montoCliente - ((montoCliente / 4) * pago.ContCuouta)).ToString() + "$";

                if (pago.Cuota1 && pago.Cuota2 && pago.Cuota3 && pago.Cuota4)
                {
                    textBox125.Font = new Font(textBox125.Font, FontStyle.Strikeout);
                }
            }
        }

        private void pictureBox64_Click(object sender, EventArgs e)
        {
            var pago = ColaPagos.BuscarPorPlaca(textBox21.Text).Dato;

            if (pago != null)
            {
                pago.Cuota4 = true;
                textBox35.Font = new Font(textBox35.Font, FontStyle.Strikeout);
                pago.ContCuouta += 1;

                var montoCliente = pago.MontoCliente;

                textBox38.Text = ((montoCliente / 4) * pago.ContCuouta).ToString() + "$";
                textBox40.Text = (montoCliente - ((montoCliente / 4) * pago.ContCuouta)).ToString() + "$";

                if (pago.Cuota1 && pago.Cuota2 && pago.Cuota3 && pago.Cuota4)
                {
                    textBox125.Font = new Font(textBox125.Font, FontStyle.Strikeout);
                }
            }
        }

        private void pictureBox80_Click(object sender, EventArgs e)
        {
            var pago = ColaPagos.BuscarPorPlaca(textBox21.Text).Dato;

            if (pago != null)
            {
                pago.Cuota1 = true;
                textBox37.Font = new Font(textBox37.Font, FontStyle.Strikeout);

                pago.Cuota2 = true;
                textBox34.Font = new Font(textBox34.Font, FontStyle.Strikeout);

                pago.Cuota3 = true;
                textBox36.Font = new Font(textBox36.Font, FontStyle.Strikeout);

                pago.Cuota4 = true;
                textBox35.Font = new Font(textBox35.Font, FontStyle.Strikeout);

                pago.ContCuouta = 4;

                textBox125.Font = new Font(textBox125.Font, FontStyle.Strikeout);

                var montoCliente = pago.MontoCliente;

                textBox38.Text = ((montoCliente / 4) * pago.ContCuouta).ToString() + "$";
                textBox40.Text = (montoCliente - ((montoCliente / 4) * pago.ContCuouta)).ToString() + "$";
            }
        }

        private void pictureBox85_Click(object sender, EventArgs e)
        {
            var pago = ColaPagos.BuscarPorPlaca(textBox102.Text).Dato;

            if (pago != null)
            {
                pago.Cuota1 = true;
                pago.ContCuouta += 1;
                textBox119.Font = new Font(textBox119.Font, FontStyle.Strikeout);

                var montoCliente = pago.MontoCliente;

                textBox99.Text = ((montoCliente / 4) * pago.ContCuouta).ToString() + "$";
                textBox49.Text = (montoCliente - ((montoCliente / 4) * pago.ContCuouta)).ToString() + "$";

                if (pago.Cuota1 && pago.Cuota2 && pago.Cuota3 && pago.Cuota4)
                {
                    textBox126.Font = new Font(textBox126.Font, FontStyle.Strikeout);
                }
            }
        }

        private void pictureBox84_Click(object sender, EventArgs e)
        {
            var pago = ColaPagos.BuscarPorPlaca(textBox102.Text).Dato;

            if (pago != null)
            {
                pago.Cuota2 = true;
                pago.ContCuouta += 1;
                textBox46.Font = new Font(textBox46.Font, FontStyle.Strikeout);

                var montoCliente = pago.MontoCliente;

                textBox99.Text = ((montoCliente / 4) * pago.ContCuouta).ToString() + "$";
                textBox49.Text = (montoCliente - ((montoCliente / 4) * pago.ContCuouta)).ToString() + "$";

                if (pago.Cuota1 && pago.Cuota2 && pago.Cuota3 && pago.Cuota4)
                {
                    textBox126.Font = new Font(textBox126.Font, FontStyle.Strikeout);
                }
            }
        }

        private void pictureBox83_Click(object sender, EventArgs e)
        {
            var pago = ColaPagos.BuscarPorPlaca(textBox102.Text).Dato;

            if (pago != null)
            {
                pago.Cuota3 = true;
                pago.ContCuouta += 1;
                textBox45.Font = new Font(textBox45.Font, FontStyle.Strikeout);

                var montoCliente = pago.MontoCliente;

                textBox99.Text = ((montoCliente / 4) * pago.ContCuouta).ToString() + "$";
                textBox49.Text = (montoCliente - ((montoCliente / 4) * pago.ContCuouta)).ToString() + "$";

                if (pago.Cuota1 && pago.Cuota2 && pago.Cuota3 && pago.Cuota4)
                {
                    textBox126.Font = new Font(textBox126.Font, FontStyle.Strikeout);
                }
            }
        }

        private void pictureBox82_Click(object sender, EventArgs e)
        {
            var pago = ColaPagos.BuscarPorPlaca(textBox102.Text).Dato;

            if (pago != null)
            {
                pago.Cuota4 = true;
                pago.ContCuouta += 1;
                textBox44.Font = new Font(textBox44.Font, FontStyle.Strikeout);

                var montoCliente = pago.MontoCliente;

                textBox99.Text = ((montoCliente / 4) * pago.ContCuouta).ToString() + "$";
                textBox49.Text = (montoCliente - ((montoCliente / 4) * pago.ContCuouta)).ToString() + "$";

                if (pago.Cuota1 && pago.Cuota2 && pago.Cuota3 && pago.Cuota4)
                {
                    textBox126.Font = new Font(textBox126.Font, FontStyle.Strikeout);
                }
            }
        }

        private void pictureBox81_Click(object sender, EventArgs e)
        {
            var pago = ColaPagos.BuscarPorPlaca(textBox102.Text).Dato;

            if (pago != null)
            {
                pago.Cuota1 = true;
                textBox119.Font = new Font(textBox119.Font, FontStyle.Strikeout);

                pago.Cuota2 = true;
                textBox46.Font = new Font(textBox46.Font, FontStyle.Strikeout);

                pago.Cuota3 = true;
                textBox45.Font = new Font(textBox45.Font, FontStyle.Strikeout);

                pago.Cuota4 = true;
                textBox44.Font = new Font(textBox44.Font, FontStyle.Strikeout);

                pago.ContCuouta = 4;

                textBox126.Font = new Font(textBox126.Font, FontStyle.Strikeout);

                var montoCliente = pago.MontoCliente;

                textBox99.Text = ((montoCliente / 4) * pago.ContCuouta).ToString() + "$";
                textBox49.Text = (montoCliente - ((montoCliente / 4) * pago.ContCuouta)).ToString() + "$";
            }
        }

        private void pictureBox48_Click(object sender, EventArgs e)
        {
            if (ColaPagos.ColaVacia())
            {
                return;
            }
            if (ContHojaPago + 2 >= ColaPagos.Cantidad())
            {
                return;
            }

            LimpiarPagos();
            ContHojaPago += 2;

            CargarPagosIzq(ColaPagos, ContHojaPago);


            Random rnd = new Random();
            int sonidoAleatorio = rnd.Next(1, 3);

            Stream sonido;
            if (sonidoAleatorio == 1)
            {
                sonido = Properties.Resources.Pagina;
            }
            else
            {
                sonido = Properties.Resources.Pagina2;
            }

            SoundPlayer player = new SoundPlayer(sonido);
            player.Play();


            if (ColaPagos.NoEsElUltimo(ContHojaPago))
            {
                CargarPagosDer(ColaPagos, ContHojaPago + 1);


                Random rnd2 = new Random();
                int sonidoAleatorio2 = rnd2.Next(1, 3);

                Stream sonido2;
                if (sonidoAleatorio2 == 1)
                {
                    sonido2 = Properties.Resources.Pagina;
                }
                else
                {
                    sonido2 = Properties.Resources.Pagina2;
                }

                SoundPlayer player2 = new SoundPlayer(sonido2);
                player2.Play();

            }
        }

        private void pictureBox44_Click(object sender, EventArgs e)
        {

            if (ContHojaPago != 0)
            {
                LimpiarPagos();
                ContHojaPago = ContHojaPago - 2;

                CargarPagosIzq(ColaPagos, ContHojaPago);

                Random rnd = new Random();
                int sonidoAleatorio = rnd.Next(1, 3);

                Stream sonido;
                if (sonidoAleatorio == 1)
                {
                    sonido = Properties.Resources.Pagina;
                }
                else
                {
                    sonido = Properties.Resources.Pagina2;
                }

                SoundPlayer player = new SoundPlayer(sonido);
                player.Play();


                if (ColaPagos.NoEsElUltimo(ContHojaPago))
                {
                    CargarPagosDer(ColaPagos, ContHojaPago + 1);

                    Random rnd2 = new Random();
                    int sonidoAleatorio2 = rnd2.Next(1, 3);
                    Stream sonido2;
                    if (sonidoAleatorio2 == 1)
                    {
                        sonido2 = Properties.Resources.Pagina;
                    }
                    else
                    {
                        sonido2 = Properties.Resources.Pagina2;
                    }

                    SoundPlayer player2 = new SoundPlayer(sonido2);
                    player2.Play();

                }
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            panel9.Visible = false;
            button12.Visible = false;
            button5.Visible = true;

            Stream sonido = Properties.Resources.Biblioteca;
            SoundPlayer player = new SoundPlayer(sonido);
            player.Play();
        }

        //////////////////////////////////////////////////Funciones complementarias de la insercion a la cola Lavado , Aspirado ,Secado/////////////////////////////////

        public void CarrosLavadosVerde()
        {
            ColaLavado.Carro();

            for (int i = 0; i < 10; i++)
            {
                ClienteReserva cliente = ColaLavado.Cantidad() > i ? ColaLavado.ColapR(i) : null;
                bool visible = ColaLavado.Cantidad() > i && ColaLavado.carrito[i];

                switch (i)
                {
                    case 0:
                        pictureBox9.Image = cliente != null && cliente.Camioneta ? Resources.Camioneta : Resources.Carro1;
                        pictureBox9.Visible = visible;
                        break;
                    case 1:
                        pictureBox10.Image = cliente != null && cliente.Camioneta ? Resources.Camioneta : Resources.Carro1;
                        pictureBox10.Visible = visible;
                        break;
                    case 2:
                        pictureBox5.Image = cliente != null && cliente.Camioneta ? Resources.Camioneta : Resources.Carro1;
                        pictureBox5.Visible = visible;
                        break;
                    case 3:
                        pictureBox6.Image = cliente != null && cliente.Camioneta ? Resources.Camioneta : Resources.Carro1;
                        pictureBox6.Visible = visible;
                        break;
                    case 4:
                        pictureBox7.Image = cliente != null && cliente.Camioneta ? Resources.Camioneta : Resources.Carro1;
                        pictureBox7.Visible = visible;
                        break;
                    case 5:
                        pictureBox8.Image = cliente != null && cliente.Camioneta ? Resources.Camioneta : Resources.Carro1;
                        pictureBox8.Visible = visible;
                        break;
                    case 6:
                        pictureBox3.Image = cliente != null && cliente.Camioneta ? Resources.Camioneta : Resources.Carro1;
                        pictureBox3.Visible = visible;
                        break;
                    case 7:
                        pictureBox4.Image = cliente != null && cliente.Camioneta ? Resources.Camioneta : Resources.Carro1;
                        pictureBox4.Visible = visible;
                        break;
                    case 8:
                        pictureBox2.Image = cliente != null && cliente.Camioneta ? Resources.Camioneta : Resources.Carro1;
                        pictureBox2.Visible = visible;
                        break;
                    case 9:
                        pictureBox65.Image = cliente != null && cliente.Camioneta ? Resources.Camioneta : Resources.Carro1;
                        pictureBox65.Visible = visible;
                        break;
                }
            }
        }
        public void CarrosAspiradosVerde()
        {
            ColaAspirado.Carro();

            for (int i = 0; i < 10; i++)
            {
                ClienteReserva cliente = ColaAspirado.Cantidad() > i ? ColaAspirado.ColapR(i) : null;
                bool visible = ColaAspirado.Cantidad() > i && ColaAspirado.carrito[i];

                switch (i)
                {
                    case 0:
                        pictureBox20.Image = cliente != null && cliente.Camioneta ? Resources.Camioneta2 : Resources.Carro2;
                        pictureBox20.Visible = visible;
                        break;
                    case 1:
                        pictureBox12.Image = cliente != null && cliente.Camioneta ? Resources.Camioneta2 : Resources.Carro2;
                        pictureBox12.Visible = visible;
                        break;
                    case 2:
                        pictureBox14.Image = cliente != null && cliente.Camioneta ? Resources.Camioneta2 : Resources.Carro2;
                        pictureBox14.Visible = visible;
                        break;
                    case 3:
                        pictureBox13.Image = cliente != null && cliente.Camioneta ? Resources.Camioneta2 : Resources.Carro2;
                        pictureBox13.Visible = visible;
                        break;
                    case 4:
                        pictureBox18.Image = cliente != null && cliente.Camioneta ? Resources.Camioneta2 : Resources.Carro2;
                        pictureBox18.Visible = visible;
                        break;
                    case 5:
                        pictureBox17.Image = cliente != null && cliente.Camioneta ? Resources.Camioneta2 : Resources.Carro2;
                        pictureBox17.Visible = visible;
                        break;
                    case 6:
                        pictureBox16.Image = cliente != null && cliente.Camioneta ? Resources.Camioneta2 : Resources.Carro2;
                        pictureBox16.Visible = visible;
                        break;
                    case 7:
                        pictureBox15.Image = cliente != null && cliente.Camioneta ? Resources.Camioneta2 : Resources.Carro2;
                        pictureBox15.Visible = visible;
                        break;
                    case 8:
                        pictureBox21.Image = cliente != null && cliente.Camioneta ? Resources.Camioneta2 : Resources.Carro2;
                        pictureBox21.Visible = visible;
                        break;
                    case 9:
                        pictureBox19.Image = cliente != null && cliente.Camioneta ? Resources.Camioneta2 : Resources.Carro2;
                        pictureBox19.Visible = visible;
                        break;
                }
            }
        }
        public void CarrosSecadosVerde()
        {
            ColaSecado.Carro();

            for (int i = 0; i < 10; i++)
            {
                ClienteReserva cliente = ColaSecado.Cantidad() > i ? ColaSecado.ColapR(i) : null;
                bool visible = ColaSecado.Cantidad() > i && ColaSecado.carrito[i];

                switch (i)
                {
                    case 0:
                        pictureBox31.Image = cliente != null && cliente.Camioneta ? Resources.Camioneta3 : Resources.Carro3;
                        pictureBox31.Visible = visible;
                        break;
                    case 1:
                        pictureBox32.Image = cliente != null && cliente.Camioneta ? Resources.Camioneta3 : Resources.Carro3;
                        pictureBox32.Visible = visible;
                        break;
                    case 2:
                        pictureBox27.Image = cliente != null && cliente.Camioneta ? Resources.Camioneta3 : Resources.Carro3;
                        pictureBox27.Visible = visible;
                        break;
                    case 3:
                        pictureBox23.Image = cliente != null && cliente.Camioneta ? Resources.Camioneta3 : Resources.Carro3;
                        pictureBox23.Visible = visible;
                        break;
                    case 4:
                        pictureBox24.Image = cliente != null && cliente.Camioneta ? Resources.Camioneta3 : Resources.Carro3;
                        pictureBox24.Visible = visible;
                        break;
                    case 5:
                        pictureBox25.Image = cliente != null && cliente.Camioneta ? Resources.Camioneta3 : Resources.Carro3;
                        pictureBox25.Visible = visible;
                        break;
                    case 6:
                        pictureBox28.Image = cliente != null && cliente.Camioneta ? Resources.Camioneta3 : Resources.Carro3;
                        pictureBox28.Visible = visible;
                        break;
                    case 7:
                        pictureBox29.Image = cliente != null && cliente.Camioneta ? Resources.Camioneta3 : Resources.Carro3;
                        pictureBox29.Visible = visible;
                        break;
                    case 8:
                        pictureBox30.Image = cliente != null && cliente.Camioneta ? Resources.Camioneta3 : Resources.Carro3;
                        pictureBox30.Visible = visible;
                        break;
                    case 9:
                        pictureBox26.Image = cliente != null && cliente.Camioneta ? Resources.Camioneta3 : Resources.Carro3;
                        pictureBox26.Visible = visible;
                        break;
                }
            }
        }
        public void CarrosAceitadosVerde()
        {
            ColaAceite.Carro();

            for (int i = 0; i < 5; i++)
            {
                ClienteReserva cliente = ColaAceite.Cantidad() > i ? ColaAceite.ColapR(i) : null;
                bool visible = ColaAceite.Cantidad() > i && ColaAceite.carrito[i];

                switch (i)
                {
                    case 0:
                        pictureBox57.Image = cliente != null && cliente.Camioneta ? Resources.Camioneta : Resources.Carro1;
                        pictureBox57.Visible = visible;
                        break;
                    case 1:
                        pictureBox58.Image = cliente != null && cliente.Camioneta ? Resources.Camioneta : Resources.Carro1;
                        pictureBox58.Visible = visible;
                        break;
                    case 2:
                        pictureBox59.Image = cliente != null && cliente.Camioneta ? Resources.Camioneta : Resources.Carro1;
                        pictureBox59.Visible = visible;
                        break;
                    case 3:
                        pictureBox60.Image = cliente != null && cliente.Camioneta ? Resources.Camioneta : Resources.Carro1;
                        pictureBox60.Visible = visible;
                        break;
                    case 4:
                        pictureBox61.Image = cliente != null && cliente.Camioneta ? Resources.Camioneta : Resources.Carro1;
                        pictureBox61.Visible = visible;
                        break;
                }
            }
        }
        public void CarrosBalanceadosVerde()
        {
            ColaCauchos.Carro();

            for (int i = 0; i < 5; i++)
            {
                ClienteReserva cliente = ColaCauchos.Cantidad() > i ? ColaCauchos.ColapR(i) : null;
                bool visible = ColaCauchos.Cantidad() > i && ColaCauchos.carrito[i];

                switch (i)
                {
                    case 0:
                        pictureBox40.Image = cliente != null && cliente.Camioneta ? Resources.Camioneta : Resources.Carro1;
                        pictureBox40.Visible = visible;
                        break;
                    case 1:
                        pictureBox41.Image = cliente != null && cliente.Camioneta ? Resources.Camioneta : Resources.Carro1;
                        pictureBox41.Visible = visible;
                        break;
                    case 2:
                        pictureBox42.Image = cliente != null && cliente.Camioneta ? Resources.Camioneta : Resources.Carro1;
                        pictureBox42.Visible = visible;
                        break;
                    case 3:
                        pictureBox55.Image = cliente != null && cliente.Camioneta ? Resources.Camioneta : Resources.Carro1;
                        pictureBox55.Visible = visible;
                        break;
                    case 4:
                        pictureBox56.Image = cliente != null && cliente.Camioneta ? Resources.Camioneta : Resources.Carro1;
                        pictureBox56.Visible = visible;
                        break;
                }
            }
        }


        ///////////////////////////////////////////////////////////Insertar a la cola Lavado,Aspirado,Secado,Aceite/////////////////////////////////////


        private void pictureBox34_Click(object sender, EventArgs e)
                {
                    var indice = 0;
                    indice = PlanillaReservas.FindIndex(ClienteReserva => ClienteReserva.LavadoR == true && ClienteReserva.EnProceso == false);
                    if (indice >= 0)
                    {

                        ColaLavado.Insertar(PlanillaReservas[indice]);
                        PlanillaReservas[indice].EnProceso = true;

                        CarrosLavadosVerde();

                    }
                    else { MessageBox.Show("No hay clientes esperando lavar el carro"); }
                }

        private void pictureBox49_Click(object sender, EventArgs e)
                {
                    var indice = 0;
                    indice = PlanillaReservas.FindIndex(ClienteReserva => ClienteReserva.AspiradoR == true && ClienteReserva.LavadoR == false && ClienteReserva.EnProceso == false);
                    if (indice >= 0)
                    {

                        ColaAspirado.Insertar(PlanillaReservas[indice]);
                        CarrosAspiradosVerde();
                    }
                    else { MessageBox.Show("No hay clientes esperando Aspirar el carro"); }

                }

        private void pictureBox39_Click(object sender, EventArgs e)
        {
            var indice = 0;
            indice = PlanillaReservas.FindIndex(ClienteReserva => ClienteReserva.SecadoR == true && ClienteReserva.AspiradoR == false && ClienteReserva.LavadoR == false && ClienteReserva.EnProceso == false);
            if (indice >= 0)
            {
                ColaSecado.Insertar(PlanillaReservas[indice]);
                CarrosSecadosVerde();
            }
            else { MessageBox.Show("No hay clientes esperando Secar el carro"); }

        }

        private void pictureBox45_Click(object sender, EventArgs e)
        {
            var indice = 0;
            indice = PlanillaReservas.FindIndex(ClienteReserva => ClienteReserva.AceiteR == true && ClienteReserva.LavadoR == false && ClienteReserva.SecadoR == false && ClienteReserva.AspiradoR == false && ClienteReserva.EnProceso == false);
            if (indice >= 0)
            {

                ColaAceite.Insertar(PlanillaReservas[indice]);
                PlanillaReservas[indice].EnProceso = true;
                CarrosAceitadosVerde();

            }
            else { MessageBox.Show("No hay clientes esperando Cambiar el Aceite del carro"); }
        }

        private void pictureBox79_Click(object sender, EventArgs e)
        {
            if(carroBalanceando == false) { carroBalanceando = true; }

            var indice = 0;
            indice = PlanillaReservas.FindIndex(ClienteReserva => ClienteReserva.BalanceoR == true && ClienteReserva.LavadoR == false && ClienteReserva.SecadoR == false && ClienteReserva.AspiradoR == false && ClienteReserva.AceiteR == false && ClienteReserva.EnProceso == false);

            if (indice >= 0)
            {
                ColaCauchos.Insertar(PlanillaReservas[indice]);
                PlanillaReservas[indice].EnProceso = true;

                int cantidadCauchos = ColaCauchos.RetirarSinPop().CantCauchos;

                CarrosBalanceadosVerde();


                if(carroBalanceando){ Cauchos(cantidadCauchos); }
            }
            else
            {
                MessageBox.Show("No hay clientes esperando Balancear los cauchos del carro");
            }
        }


        //////////////////////////////////////////////////////////ToolTips del Lavado//////////////////////////////////////////////////

        private void pictureBox9_MouseHover(object sender, EventArgs e)
        {
            toolTip0.AutoPopDelay = 10000;
            toolTip0.InitialDelay = 100;
            toolTip0.ReshowDelay = 100;
            toolTip0.ShowAlways = false;
            toolTip0.SetToolTip(this.pictureBox9, ColaLavado.Nombre(0) + " " + Convert.ToString(ColaLavado.ID(0)));
        }

        private void pictureBox10_MouseHover(object sender, EventArgs e)
        {
            toolTip1.AutoPopDelay = 10000;
            toolTip1.InitialDelay = 100;
            toolTip1.ReshowDelay = 100;
            toolTip1.ShowAlways = false;
            toolTip1.SetToolTip(this.pictureBox10, ColaLavado.Nombre(1) + " " + Convert.ToString(ColaLavado.ID(1)));
        }

        private void pictureBox5_MouseHover(object sender, EventArgs e)
        {
            toolTip2.AutoPopDelay = 10000;
            toolTip2.InitialDelay = 100;
            toolTip2.ReshowDelay = 100;
            toolTip2.ShowAlways = false;
            toolTip2.SetToolTip(this.pictureBox5, ColaLavado.Nombre(2) + " " + Convert.ToString(ColaLavado.ID(2)));
        }

        private void pictureBox6_MouseHover(object sender, EventArgs e)
        {
            toolTip3.AutoPopDelay = 10000;
            toolTip3.InitialDelay = 100;
            toolTip3.ReshowDelay = 100;
            toolTip3.ShowAlways = false;
            toolTip3.SetToolTip(this.pictureBox6, ColaLavado.Nombre(3) + " " + Convert.ToString(ColaLavado.ID(3)));
        }

        private void pictureBox7_MouseHover(object sender, EventArgs e)
        {
            toolTip4.AutoPopDelay = 10000;
            toolTip4.InitialDelay = 100;
            toolTip4.ReshowDelay = 100;
            toolTip4.ShowAlways = false;
            toolTip4.SetToolTip(this.pictureBox7, ColaLavado.Nombre(4) + " " + Convert.ToString(ColaLavado.ID(4)));
        }

        private void pictureBox8_MouseHover(object sender, EventArgs e)
        {
            toolTip5.AutoPopDelay = 10000;
            toolTip5.InitialDelay = 100;
            toolTip5.ReshowDelay = 100;
            toolTip5.ShowAlways = false;
            toolTip5.SetToolTip(this.pictureBox8, ColaLavado.Nombre(5) + " " + Convert.ToString(ColaLavado.ID(5)));
        }

        private void pictureBox3_MouseHover(object sender, EventArgs e)
        {
            toolTip6.AutoPopDelay = 10000;
            toolTip6.InitialDelay = 100;
            toolTip6.ReshowDelay = 100;
            toolTip6.ShowAlways = false;
            toolTip6.SetToolTip(this.pictureBox3, ColaLavado.Nombre(6) + " " + Convert.ToString(ColaLavado.ID(6)));
        }

        private void pictureBox4_MouseHover(object sender, EventArgs e)
        {
            toolTip7.AutoPopDelay = 10000;
            toolTip7.InitialDelay = 100;
            toolTip7.ReshowDelay = 100;
            toolTip7.ShowAlways = false;
            toolTip7.SetToolTip(this.pictureBox4, ColaLavado.Nombre(7) + " " + Convert.ToString(ColaLavado.ID(7)));
        }

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            toolTip8.AutoPopDelay = 10000;
            toolTip8.InitialDelay = 100;
            toolTip8.ReshowDelay = 100;
            toolTip8.ShowAlways = false;
            toolTip8.SetToolTip(this.pictureBox2, ColaLavado.Nombre(8) + " " + Convert.ToString(ColaLavado.ID(8)));
        }

        private void pictureBox65_MouseHover(object sender, EventArgs e)
        {
            toolTip9.AutoPopDelay = 10000;
            toolTip9.InitialDelay = 100;
            toolTip9.ReshowDelay = 100;
            toolTip9.ShowAlways = false;
            toolTip9.SetToolTip(this.pictureBox65, ColaLavado.Nombre(9) + " " + Convert.ToString(ColaLavado.ID(9)));
        }


        //////////////////////////////////////////////////////////ToolTips del Aspirado//////////////////////////////////////////////////

        private void pictureBox20_MouseHover(object sender, EventArgs e)
        {
            toolTip10.AutoPopDelay = 10000;
            toolTip10.InitialDelay = 100;
            toolTip10.ReshowDelay = 100;
            toolTip10.ShowAlways = false;
            toolTip10.SetToolTip(this.pictureBox20, ColaAspirado.Nombre(0) + " " + Convert.ToString(ColaAspirado.ID(0)));
        }

        private void pictureBox12_MouseHover(object sender, EventArgs e)
        {
            toolTip11.AutoPopDelay = 10000;
            toolTip11.InitialDelay = 100;
            toolTip11.ReshowDelay = 100;
            toolTip11.ShowAlways = false;
            toolTip11.SetToolTip(this.pictureBox12, ColaAspirado.Nombre(1) + " " + Convert.ToString(ColaAspirado.ID(1)));
        }

        private void pictureBox14_MouseHover(object sender, EventArgs e)
        {
            toolTip12.AutoPopDelay = 10000;
            toolTip12.InitialDelay = 100;
            toolTip12.ReshowDelay = 100;
            toolTip12.ShowAlways = false;
            toolTip12.SetToolTip(this.pictureBox14, ColaAspirado.Nombre(2) + " " + Convert.ToString(ColaAspirado.ID(2)));
        }

        private void pictureBox13_MouseHover(object sender, EventArgs e)
        {
            toolTip13.AutoPopDelay = 10000;
            toolTip13.InitialDelay = 100;
            toolTip13.ReshowDelay = 100;
            toolTip13.ShowAlways = false;
            toolTip13.SetToolTip(this.pictureBox13, ColaAspirado.Nombre(3) + " " + Convert.ToString(ColaAspirado.ID(3)));
        }

        private void pictureBox18_MouseHover(object sender, EventArgs e)
        {
            toolTip14.AutoPopDelay = 10000;
            toolTip14.InitialDelay = 100;
            toolTip14.ReshowDelay = 100;
            toolTip14.ShowAlways = false;
            toolTip14.SetToolTip(this.pictureBox18, ColaAspirado.Nombre(4) + " " + Convert.ToString(ColaAspirado.ID(4)));
        }

        private void pictureBox17_MouseHover(object sender, EventArgs e)
        {
            toolTip15.AutoPopDelay = 10000;
            toolTip15.InitialDelay = 100;
            toolTip15.ReshowDelay = 100;
            toolTip15.ShowAlways = false;
            toolTip15.SetToolTip(this.pictureBox17, ColaAspirado.Nombre(5) + " " + Convert.ToString(ColaAspirado.ID(5)));
        }

        private void pictureBox16_MouseHover(object sender, EventArgs e)
        {
            toolTip16.AutoPopDelay = 10000;
            toolTip16.InitialDelay = 100;
            toolTip16.ReshowDelay = 100;
            toolTip16.ShowAlways = false;
            toolTip16.SetToolTip(this.pictureBox16, ColaAspirado.Nombre(6) + " " + Convert.ToString(ColaAspirado.ID(6)));
        }

        private void pictureBox15_MouseHover(object sender, EventArgs e)
        {
            toolTip17.AutoPopDelay = 10000;
            toolTip17.InitialDelay = 100;
            toolTip17.ReshowDelay = 100;
            toolTip17.ShowAlways = false;
            toolTip17.SetToolTip(this.pictureBox15, ColaAspirado.Nombre(7) + " " + Convert.ToString(ColaAspirado.ID(7)));
        }

        private void pictureBox21_MouseHover(object sender, EventArgs e)
        {
            toolTip18.AutoPopDelay = 10000;
            toolTip18.InitialDelay = 100;
            toolTip18.ReshowDelay = 100;
            toolTip18.ShowAlways = false;
            toolTip18.SetToolTip(this.pictureBox21, ColaAspirado.Nombre(8) + " " + Convert.ToString(ColaAspirado.ID(8)));
        }

        private void pictureBox19_MouseHover(object sender, EventArgs e)
        {
            toolTip19.AutoPopDelay = 10000;
            toolTip19.InitialDelay = 100;
            toolTip19.ReshowDelay = 100;
            toolTip19.ShowAlways = false;
            toolTip19.SetToolTip(this.pictureBox19, ColaAspirado.Nombre(9) + " " + Convert.ToString(ColaAspirado.ID(9)));
        }


        ///////////////////////////////////////////////////////////ToolTips de Secado//////////////////////////////////////////////////////////////////////////////////

        private void pictureBox31_MouseHover(object sender, EventArgs e)
        {
            toolTip20.AutoPopDelay = 10000;
            toolTip20.InitialDelay = 100;
            toolTip20.ReshowDelay = 100;
            toolTip20.ShowAlways = false;
            toolTip20.SetToolTip(this.pictureBox31, ColaSecado.Nombre(0) + " " + Convert.ToString(ColaSecado.ID(0)));
        }

        private void pictureBox32_MouseHover(object sender, EventArgs e)
        {
            toolTip21.AutoPopDelay = 10000;
            toolTip21.InitialDelay = 100;
            toolTip21.ReshowDelay = 100;
            toolTip21.ShowAlways = false;
            toolTip21.SetToolTip(this.pictureBox32, ColaSecado.Nombre(1) + " " + Convert.ToString(ColaSecado.ID(1)));
        }

        private void pictureBox27_MouseHover(object sender, EventArgs e)
        {
            toolTip22.AutoPopDelay = 10000;
            toolTip22.InitialDelay = 100;
            toolTip22.ReshowDelay = 100;
            toolTip22.ShowAlways = false;
            toolTip22.SetToolTip(this.pictureBox27, ColaSecado.Nombre(2) + " " + Convert.ToString(ColaSecado.ID(2)));
        }

        private void pictureBox23_MouseHover(object sender, EventArgs e)
        {
            toolTip23.AutoPopDelay = 10000;
            toolTip23.InitialDelay = 100;
            toolTip23.ReshowDelay = 100;
            toolTip23.ShowAlways = false;
            toolTip23.SetToolTip(this.pictureBox23, ColaSecado.Nombre(3) + " " + Convert.ToString(ColaSecado.ID(3)));
        }

        private void pictureBox24_MouseHover(object sender, EventArgs e)
        {
            toolTip24.AutoPopDelay = 10000;
            toolTip24.InitialDelay = 100;
            toolTip24.ReshowDelay = 100;
            toolTip24.ShowAlways = false;
            toolTip24.SetToolTip(this.pictureBox24, ColaSecado.Nombre(4) + " " + Convert.ToString(ColaSecado.ID(4)));
        }

        private void pictureBox25_MouseHover(object sender, EventArgs e)
        {
            toolTip25.AutoPopDelay = 10000;
            toolTip25.InitialDelay = 100;
            toolTip25.ReshowDelay = 100;
            toolTip25.ShowAlways = false;
            toolTip25.SetToolTip(this.pictureBox25, ColaSecado.Nombre(5) + " " + Convert.ToString(ColaSecado.ID(5)));
        }

        private void pictureBox28_MouseHover(object sender, EventArgs e)
        {
            toolTip26.AutoPopDelay = 10000;
            toolTip26.InitialDelay = 100;
            toolTip26.ReshowDelay = 100;
            toolTip26.ShowAlways = false;
            toolTip26.SetToolTip(this.pictureBox28, ColaSecado.Nombre(6) + " " + Convert.ToString(ColaSecado.ID(6)));
        }

        private void pictureBox29_MouseHover(object sender, EventArgs e)
        {
            toolTip27.AutoPopDelay = 10000;
            toolTip27.InitialDelay = 100;
            toolTip27.ReshowDelay = 100;
            toolTip27.ShowAlways = false;
            toolTip27.SetToolTip(this.pictureBox29, ColaSecado.Nombre(7) + " " + Convert.ToString(ColaSecado.ID(7)));
        }

        private void pictureBox30_MouseHover(object sender, EventArgs e)
        {
            toolTip28.AutoPopDelay = 10000;
            toolTip28.InitialDelay = 100;
            toolTip28.ReshowDelay = 100;
            toolTip28.ShowAlways = false;
            toolTip28.SetToolTip(this.pictureBox30, ColaSecado.Nombre(8) + " " + Convert.ToString(ColaSecado.ID(8)));
        }

        private void pictureBox26_MouseHover(object sender, EventArgs e)
        {
            toolTip29.AutoPopDelay = 10000;
            toolTip29.InitialDelay = 100;
            toolTip29.ReshowDelay = 100;
            toolTip29.ShowAlways = false;
            toolTip29.SetToolTip(this.pictureBox26, ColaSecado.Nombre(9) + " " + Convert.ToString(ColaSecado.ID(9)));
        }


        ///////////////////////////////////////////////////////////ToolTips de Aceite//////////////////////////////////////////////////////////////////////////////////

        private void pictureBox57_MouseHover_1(object sender, EventArgs e)
        {
            toolTip30.AutoPopDelay = 10000;
            toolTip30.InitialDelay = 100;
            toolTip30.ReshowDelay = 100;
            toolTip30.ShowAlways = false;
            toolTip30.SetToolTip(this.pictureBox57, ColaAceite.Nombre(0) + " " + Convert.ToString(ColaAceite.ID(0)));
        }

        private void pictureBox58_MouseHover_1(object sender, EventArgs e)
        {
            toolTip31.AutoPopDelay = 10000;
            toolTip31.InitialDelay = 100;
            toolTip31.ReshowDelay = 100;
            toolTip31.ShowAlways = false;
            toolTip31.SetToolTip(this.pictureBox58, ColaAceite.Nombre(1) + " " + Convert.ToString(ColaAceite.ID(1)));
        }

        private void pictureBox59_MouseHover_1(object sender, EventArgs e)
        {
            toolTip32.AutoPopDelay = 10000;
            toolTip32.InitialDelay = 100;
            toolTip32.ReshowDelay = 100;
            toolTip32.ShowAlways = false;
            toolTip32.SetToolTip(this.pictureBox59, ColaAceite.Nombre(2) + " " + Convert.ToString(ColaAceite.ID(2)));
        }

        private void pictureBox60_MouseHover_1(object sender, EventArgs e)
        {
            toolTip33.AutoPopDelay = 10000;
            toolTip33.InitialDelay = 100;
            toolTip33.ReshowDelay = 100;
            toolTip33.ShowAlways = false;
            toolTip33.SetToolTip(this.pictureBox60, ColaAceite.Nombre(3) + " " + Convert.ToString(ColaAceite.ID(3)));
        }

        private void pictureBox61_MouseHover_1(object sender, EventArgs e)
        {
            toolTip34.AutoPopDelay = 10000;
            toolTip34.InitialDelay = 100;
            toolTip34.ReshowDelay = 100;
            toolTip34.ShowAlways = false;
            toolTip34.SetToolTip(this.pictureBox61, ColaAceite.Nombre(4) + " " + Convert.ToString(ColaAceite.ID(4)));
        }


        ///////////////////////////////////////////////////////////ToolTips de Cauchoos//////////////////////////////////////////////////////////////////////////////////

        private void pictureBox40_MouseHover(object sender, EventArgs e)
        {
            toolTip35.AutoPopDelay = 10000;
            toolTip35.InitialDelay = 100;
            toolTip35.ReshowDelay = 100;
            toolTip35.ShowAlways = false;
            toolTip35.SetToolTip(this.pictureBox40, ColaCauchos.Nombre(0) + " " + Convert.ToString(ColaCauchos.ID(0)));
        }

        private void pictureBox41_MouseHover(object sender, EventArgs e)
        {
            toolTip36.AutoPopDelay = 10000;
            toolTip36.InitialDelay = 100;
            toolTip36.ReshowDelay = 100;
            toolTip36.ShowAlways = false;
            toolTip36.SetToolTip(this.pictureBox41, ColaCauchos.Nombre(1) + " " + Convert.ToString(ColaCauchos.ID(0)));
        }

        private void pictureBox42_MouseHover(object sender, EventArgs e)
        {
            toolTip37.AutoPopDelay = 10000;
            toolTip37.InitialDelay = 100;
            toolTip37.ReshowDelay = 100;
            toolTip37.ShowAlways = false;
            toolTip37.SetToolTip(this.pictureBox42, ColaCauchos.Nombre(2) + " " + Convert.ToString(ColaCauchos.ID(0)));
        }

        private void pictureBox55_MouseHover(object sender, EventArgs e)
        {
            toolTip38.AutoPopDelay = 10000;
            toolTip38.InitialDelay = 100;
            toolTip38.ReshowDelay = 100;
            toolTip38.ShowAlways = false;
            toolTip38.SetToolTip(this.pictureBox55, ColaCauchos.Nombre(3) + " " + Convert.ToString(ColaCauchos.ID(0)));
        }

        private void pictureBox56_MouseHover(object sender, EventArgs e)
        {
            toolTip39.AutoPopDelay = 10000;
            toolTip39.InitialDelay = 100;
            toolTip39.ReshowDelay = 100;
            toolTip39.ShowAlways = false;
            toolTip39.SetToolTip(this.pictureBox56, ColaCauchos.Nombre(4) + " " + Convert.ToString(ColaCauchos.ID(0)));
        }


        /////////////////////////////////////////////////////////////Botones de Play//////////////////////////////////////////////////////////////////////////////////////////////

        private void pictureBox36_Click(object sender, EventArgs e)
        {
            if (ColaLavado.ColaVacia())
            {
                MessageBox.Show("ERROR: No hay clientes esperando por el servicio.");
                return;
            }

            var indice = 0;
            indice = PlanillaReservas.FindIndex(ClienteReserva => ClienteReserva.LavadoR == true);

            ClienteReserva cliente = ColaLavado.RetirarSinPop();

            if (cliente.AspiradoR)
            {
                ColaAspirado.Insertar(ColaLavado.Retirar());
                CarrosAspiradosVerde();
            }
            else if (cliente.SecadoR)
            {
                ColaSecado.Insertar(ColaLavado.Retirar());
                CarrosSecadosVerde();
            }
            else if (cliente.AceiteR)
            {
                ColaAceite.Insertar(ColaLavado.Retirar());
                CarrosAceitadosVerde();
            }
            else if (cliente.BalanceoR)
            {
                ColaCauchos.Insertar(ColaLavado.Retirar());
                CarrosBalanceadosVerde();

                if (!carroBalanceando) { Cauchos(ColaCauchos.RetirarSinPop().CantCauchos); }
            }
            else
            {

                ColaPagos.Insertar(ColaLavado.RetirarSinPop());
                ColaFactura.Insertar(ColaLavado.Retirar());
  
                PlanillaReservas.Remove(PlanillaReservas[indice]);
                AdapatarEspera();
            }

            CarrosLavadosVerde();
        }

        private void pictureBox47_Click(object sender, EventArgs e)
        {
            if (ColaAspirado.ColaVacia())
            {
                MessageBox.Show("ERROR: No hay clientes esperando por el servicio.");
                return;
            }

            var indice = 0;
            indice = PlanillaReservas.FindIndex(ClienteReserva => ClienteReserva.AspiradoR == true);

            ClienteReserva cliente = ColaAspirado.RetirarSinPop();

            if (cliente.SecadoR)
            {
                ColaSecado.Insertar(ColaAspirado.Retirar());
                CarrosSecadosVerde();
            }
            else if (cliente.AceiteR)
            {
                ColaAceite.Insertar(ColaAspirado.Retirar());
                CarrosAceitadosVerde();
            }
            else if (cliente.BalanceoR)
            {
                ColaCauchos.Insertar(ColaAspirado.Retirar());
                CarrosBalanceadosVerde();

                if (!carroBalanceando) { Cauchos(ColaCauchos.RetirarSinPop().CantCauchos); }
            }
            else
            {
                ColaPagos.Insertar(ColaAspirado.RetirarSinPop());
                ColaFactura.Insertar(ColaAspirado.Retirar());

                PlanillaReservas.Remove(PlanillaReservas[indice]);
                AdapatarEspera();
            }

            CarrosAspiradosVerde();
        }

        private void pictureBox37_Click(object sender, EventArgs e)
        {
            if (ColaSecado.ColaVacia())
            {
                MessageBox.Show("ERROR: No hay clientes esperando por el servicio.");
                return;
            }

            var indice = 0;
            indice = PlanillaReservas.FindIndex(ClienteReserva => ClienteReserva.SecadoR == true);

            ClienteReserva cliente = ColaSecado.RetirarSinPop();

            if (cliente.AceiteR)
            {
                ColaAceite.Insertar(ColaSecado.Retirar());
                CarrosAceitadosVerde();
            }
            else if (cliente.BalanceoR)
            {
                ColaCauchos.Insertar(ColaSecado.Retirar());
                CarrosBalanceadosVerde();

                if (!carroBalanceando) { Cauchos(ColaCauchos.RetirarSinPop().CantCauchos); }
            }
            else
            {
                ColaPagos.Insertar(ColaSecado.RetirarSinPop());
                ColaFactura.Insertar(ColaSecado.Retirar());

                PlanillaReservas.Remove(PlanillaReservas[indice]);
                AdapatarEspera();
            }

            CarrosSecadosVerde();
        }

        private void pictureBox43_Click(object sender, EventArgs e)
        {
            if (ColaAceite.ColaVacia())
            {
                MessageBox.Show("ERROR: No hay clientes esperando por el servicio.");
                return;
            }

            var indice = 0;
            indice = PlanillaReservas.FindIndex(ClienteReserva => ClienteReserva.AceiteR == true);

            ClienteReserva cliente = ColaAceite.RetirarSinPop();

            if (cliente.BalanceoR)
            {
                ColaCauchos.Insertar(ColaAceite.Retirar());
                CarrosBalanceadosVerde();

                if (!carroBalanceando) { Cauchos(ColaCauchos.RetirarSinPop().CantCauchos); }
            }
            else
            {
                ColaPagos.Insertar(ColaAceite.RetirarSinPop());
                ColaFactura.Insertar(ColaAceite.Retirar());

                PlanillaReservas.Remove(PlanillaReservas[indice]);
                AdapatarEspera();
            }

            CarrosAceitadosVerde();
        }

        private void pictureBox77_Click(object sender, EventArgs e)
        {
            if (ColaCauchos.ColaVacia())
            {
                MessageBox.Show("ERROR: No hay clientes esperando por el servicio.");
                return;
            }

            ClienteReserva cliente = ColaCauchos.RetirarSinPop();

            if (cliente.CantCauchos <= 0)
            {
                ColaPagos.Insertar(ColaCauchos.RetirarSinPop());
                ColaFactura.Insertar(ColaCauchos.Retirar());

                PlanillaReservas.Remove(cliente);
                AdapatarEspera();
                CarrosBalanceadosVerde();
                carroBalanceando = false;   

                if (!ColaCauchos.ColaVacia())
                {
                    ClienteReserva siguienteCliente = ColaCauchos.RetirarSinPop();
                    ContCauchos = siguienteCliente.CantCauchos;
                    Cauchos(ContCauchos);
                }
                else
                {
                    ContCauchos = 0; // apendice
                    carroBalanceando = false;

                }
            }
            else
            {
                cliente.CantCauchos -= 1;
                Cauchos(cliente.CantCauchos);
            }
        }


        /////////////////////////////////////////////////////Modificar un Cliente////////////////////////////////////////
        private void materialFloatingActionButton3_Click(object sender, EventArgs e)
        {
            int id;
            if (!int.TryParse(materialMaskedTextBox10.Text, out id))
            {
                MessageBox.Show("Debes introducir una ID válida.");
                return;
            }

            var indice = Planilla.FindIndex(Cliente => Cliente.ID.Equals(id));
            if (indice < 0)
            {
                MessageBox.Show("Cliente no encontrado");
                return;
            }

            Planilla[indice].NombreCompleto = materialMaskedTextBox9.Text;
            Planilla[indice].CI = materialMaskedTextBox7.Text;
            Planilla[indice].ModeloVehiculo = materialMaskedTextBox6.Text;
            Planilla[indice].Placa = materialMaskedTextBox5.Text;
            Planilla[indice].Camioneta = materialRadioButton4.Checked;

           // pictureBox66.Image = Resources.Exito;
            //pictureBox66.Image = Resources.Gif1_TV3;
            CargarPlanilla();
            panel5.Visible = false;
        }


        /////////////////////////////////////////////////////Eliminar un Cliente////////////////////////////////////////

        private void materialFloatingActionButton4_Click(object sender, EventArgs e)
        {
            int id;
            if (!int.TryParse(materialMaskedTextBox11.Text, out id))
            {
                MessageBox.Show("Debes introducir una ID válida.");
                return;
            }

            var indice = Planilla.FindIndex(Cliente => Cliente.ID.Equals(id));
            if (indice < 0)
            {
                MessageBox.Show("Cliente no encontrado");
                return;
            }

            Planilla.Remove(Planilla[indice]);
            CargarPlanilla();
        }


        //////////////////////////////////////////////////////Cancelar un servicio//////////////////////////////////////////////

        private void CancelarServicio(int ID, bool Lavado, bool Aspirado, bool Secado, bool Balanceo, bool Aceite)
        {
            if (Lavado)
            {

                var indice = 0;
                indice = PlanillaReservas.FindIndex(ClienteReserva => ClienteReserva.ID == ID);
                if (indice != -1) {
                    PlanillaReservas.Remove(PlanillaReservas[indice]);
                    CargarPlanilla();
                }

                for (int i = 0; i < ColaLavado.Cantidad(); i++)
                {
                    if (ColaLavado.ColapR(i).ID == ID)
                    {
                        if (ColaLavado.ColapR(i).LavadoR)
                        {
                            ColaLavado.RetirarEspecifco(i);
                            CarrosLavadosVerde();
                        }
                        else { MessageBox.Show("El cliente no reservo el servicio de Lavado"); }
                    }
                }
            }

            if (Aspirado)
            {
                var indice = 0;
                indice = PlanillaReservas.FindIndex(ClienteReserva => ClienteReserva.ID == ID);
                if (indice != -1)
                {
                    PlanillaReservas.Remove(PlanillaReservas[indice]);
                    CargarPlanilla();
                }

                for (int i = 0; i < ColaAspirado.Cantidad(); i++)
                {
                    if (ColaAspirado.ColapR(i).ID == ID)
                    {
                        if (ColaAspirado.ColapR(i).AspiradoR)
                        {
                            ColaAspirado.RetirarEspecifco(i);
                            CarrosAspiradosVerde();
                        }
                        else { MessageBox.Show("El cliente no reservo el servicio de Aspirado"); }
                    }
                }
            }

            if (Secado)
            {
                var indice = 0;
                indice = PlanillaReservas.FindIndex(ClienteReserva => ClienteReserva.ID == ID);
                if (indice != -1)
                {
                    PlanillaReservas.Remove(PlanillaReservas[indice]);
                    CargarPlanilla();
                }

                for (int i = 0; i < ColaSecado.Cantidad(); i++)
                {
                    if (ColaSecado.ColapR(i).ID == ID)
                    {
                        if (ColaSecado.ColapR(i).SecadoR)
                        {
                            ColaSecado.RetirarEspecifco(i);
                            CarrosSecadosVerde();
                        }
                        else { MessageBox.Show("El cliente no reservo el servicio de Secado"); }
                    }
                }
            }

            //hacer los de aceite y cauchos y sacar del datagrid


        }


        private void materialFloatingActionButton5_Click(object sender, EventArgs e)
        {
            int id;
            if (!int.TryParse(materialMaskedTextBox12.Text, out id))
            {
                MessageBox.Show("Debes introducir una ID válida.");
                return;
            }

            CancelarServicio(id,
                             materialCheckbox14.Checked,
                             materialCheckbox13.Checked,
                             materialCheckbox12.Checked,
                             materialCheckbox10.Checked,
                             materialCheckbox9.Checked);
        }

        ///////////////////////////////////////////////////////Filtrar Reservas//////////////////////////////////////////////////

        private void textBox14_TextChanged(object sender, EventArgs e)
        {
            BuscarCliente();
        }

    }
}