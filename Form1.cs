using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculadora
{
    public partial class Form1 : Form
    {
        // Variável global:
        bool clicouNoOperador = true;
        string ultiop;
        public Form1()
        {
            InitializeComponent();
        }

        private void Numero_Click(object sender, EventArgs e)
        {
           var btnClicado = sender as Button;
            txtTela.Text += btnClicado.Text;

            clicouNoOperador = false;
        }
        private void Operacao_Click(object sender, EventArgs e)
        {
            var btnClicado = sender as Button;

            // Só atribuir na tela se não tiver clicado no operador:
            // E tambem se voce já tiver clicado um operador, não sera possivel adicionar novamente
            // somente se colocar um numero.
            if (clicouNoOperador == false)
            {

                txtTela.Text += btnClicado.Text;
                ultiop = btnClicado.Text;

                if (ultiop == "+" || ultiop == "-" || ultiop == "*" || ultiop == "/")
                {
                    clicouNoOperador = true;

                }
                



            }

            
        }

        private void btnIgual_Click(object sender, EventArgs e)
        {

            DataTable dt = new DataTable();
            txtTela.Text = dt.Compute(txtTela.Text, "").ToString();

            if (txtTela.Text == "∞" || txtTela.Text == "0")
            {
                txtTela.Text = "";
                MessageBox.Show("Não pode ser dividido por 0", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        
        

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtTela.Text = "";
           
        }
    }
}