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
        bool ativo = true;
        string id;
        public frmCargos()
        {
            InitializeComponent();
        }

        private void frmCargos_Load(object sender, EventArgs e)
        {
            HabilitarBotaoNovo();
            Listar();
        }


        private void btnNovo_Click(object sender, EventArgs e)
        {
            txtCargo.Clear();
            HabilitarSalvar();
            HabilitarCampos(ativo);

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCargo.Text.Trim()))
            {
                MessageBox.Show("Preencha o Cargo!", "Cadastro Cargo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCargo.Clear();
                txtCargo.Focus();
                return;
            }
            else
            {
                conexao.AbrirConexao();
                sql = "INSERT INTO cargos(cargo) VALUES (@cargo);";
                cmd = new MySqlCommand(sql, conexao.conexao);
                cmd.Parameters.AddWithValue("@cargo", txtCargo.Text);

                cmd.ExecuteNonQuery();
                conexao.FecharConexao();
                MessageBox.Show("Novo Cargo Salvo!", "Cadastro Cargo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Resetar();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCargo.Text.Trim()))
            {
                MessageBox.Show("Preencha o Cargos!", "Cadastro Cargo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCargo.Focus();
                return;
            }
            else
            {
                conexao.AbrirConexao();
                sql = "UPDATE cargos SET cargo = @cargo WHERE id = @id;";
                cmd = new MySqlCommand(sql, conexao.conexao);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@cargo", txtCargo.Text);
                cmd.ExecuteNonQuery();
                conexao.FecharConexao();

                MessageBox.Show("Cargo Atualizado!", "Cadastro Cargo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Resetar();
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Certeza que deseja excluir esse cargo?\n\n" +
                "Essa ação não pode ser revertida!", "Cadastro Cargo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (res == DialogResult.OK)
            {
                string cargoExcluido = (txtCargo.Text).ToString();
                conexao.AbrirConexao();
                cmd = new MySqlCommand("DELETE FROM cargos WHERE id = @id;", conexao.conexao);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                conexao.FecharConexao();
                
                MessageBox.Show($"**{cargoExcluido}** excluido do cadastro de cargos!");
                Resetar();
            }
            else
            {
                return;
            }
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
            HabilitarBotaoNovo();
            Listar();
        }

        private void grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                PreencherCampos();
                txtCargo.Enabled = false;
                HabilitarEdicao();
            }
            else
            {
                return;
            }
        }
        private void grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                PreencherCampos();
                grid.Enabled = false;
                HabilitarEdicao();
                HabilitarCampos(ativo);

            }
            else
            {
                return;
            }
        }
        private void HabilitarBotaoNovo()
        {
            txtCargo.Clear();
            grid.Enabled = true;
            HabilitarCampos(!ativo);
            btnNovo.Enabled = true;
            btnSalvar.Enabled = false;
            btnEditar.Enabled = false;
            btnExcluir.Enabled = false;
        }
        private void HabilitarSalvar()
        {
            grid.Enabled = false;
            btnNovo.Enabled= false;
            btnSalvar.Enabled= true;
            btnEditar.Enabled= false;
            btnExcluir.Enabled= false;
        }
        private void HabilitarEdicao()
        {
            btnNovo.Enabled = false;
            btnSalvar.Enabled = false;
            btnEditar.Enabled = true;
            btnExcluir.Enabled = true;

            
        }
        private void HabilitarCampos(bool ativo)
        {
           if (ativo)
            {
                txtCargo.Enabled = true;
                txtCargo.Focus();
            }
           else
            {
                txtCargo.Enabled = false;
            }
        }
        private void PreencherCampos()
        {
            id = grid.CurrentRow.Cells[0].Value.ToString();
            txtCargo.Text = grid.CurrentRow.Cells[1].Value.ToString();
        }
    }
}
