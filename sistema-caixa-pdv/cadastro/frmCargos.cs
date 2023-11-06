using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sistema_caixa_pdv.cadastro
{    
    public partial class frmCargos : Form
    {
        Conexao conexao = new Conexao();
        string sql;
        MySqlCommand cmd;
        public frmCargos()
        {
            InitializeComponent();
        }

        private void frmCargos_Load(object sender, EventArgs e)
        {
            Listar();
        }


        private void btnNovo_Click(object sender, EventArgs e)
        {
            HabilitarEdicao();
            txtCargo.Enabled = true;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            conexao.AbrirConexao();
            sql = "INSERT INTO cargos(cargo) VALUES (@cargo);";
            cmd = new MySqlCommand(sql, conexao.conexao);

            
            conexao.FecharConexao();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {

        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Resetar();
        }
        private void Listar()
        {
            conexao.AbrirConexao();
            sql = "SELECT * FROM Cargos;";
            cmd = new MySqlCommand(sql, conexao.conexao);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            grid.DataSource = dt;

            conexao.FecharConexao();
        }
        private void Resetar()
        {
            txtCargo.Clear();
            HabilitarBotaoNovo();
            Listar();
        }

        private void grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void HabilitarBotaoNovo()
        {
            txtCargo.Clear();
            grid.Enabled = true;
            txtCargo.Enabled = false;
            btnNovo.Enabled = true;
            btnSalvar.Enabled = false;
            btnEditar.Enabled = false;
            btnExcluir.Enabled = false;
        }
        private void HabilitarEdicao()
        {
            btnNovo.Enabled=false;
            btnSalvar.Enabled=true;
            btnEditar.Enabled=true;
            btnExcluir.Enabled=true;

            grid.Enabled = false;
        }
        
    }
}
