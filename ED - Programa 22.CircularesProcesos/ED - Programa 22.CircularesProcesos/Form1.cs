using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ED___Programa_22.CircularesProcesos
{
    public partial class Form1 : Form
    {
        Procesador procesador = new Procesador();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            txtInfo.Clear();
            procesador.procesar(20);
            txtInfo.Text = procesador.ToString() + Environment.NewLine +
                "Ciclos vacíos: " + procesador.vacios.ToString() +
                "\r\nProcesos atendidos por completo: " + procesador.pAtendidos.ToString() +
                "\r\nNúmero máximo de procesos formados: " + procesador.pMaximos.ToString();
        }
    }
}
