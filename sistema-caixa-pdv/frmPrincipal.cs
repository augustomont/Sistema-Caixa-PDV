using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sistema_caixa_pdv
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void menuSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void menuCadastroFuncionario_Click(object sender, EventArgs e)
        {
            cadastro.frmFuncionario frm = new cadastro.frmFuncionario();
            frm.ShowDialog();
        }
    }
}
